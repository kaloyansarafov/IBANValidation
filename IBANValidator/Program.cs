using System;
using IbanNet;
using System.Text.RegularExpressions;
using System.Text;
using System.Numerics;
using System.Collections.Generic;

namespace IBANValidator
{
    class Program
    {

        static void Main()
        {
            Console.WriteLine("1. Validate using Library");
            Console.WriteLine("2. Validate using regex");
            string input = Console.ReadLine();
            Console.WriteLine("enter IBAN");
            string IBAN = Console.ReadLine();

            if (input == "1")
            {
                IIbanValidator validator = new IbanValidator();
                ValidationResult validationResult = validator.Validate(IBAN);
                if (validationResult.IsValid)
                {
                    Console.WriteLine("IBAN is valid");
                }
                else if (!validationResult.IsValid)
                {
                    Console.WriteLine("IBAN is invalid");
                }

            }

            if (input == "2")
            {
                if (CheckIBAN(IBAN))
                {
                    Console.WriteLine("IBAN is valid");
                }
                else
                {
                    Console.WriteLine("IBAN is invalid");
                }

            }
        }

        static bool CheckIBAN(string input)
        {
            string pattern = @"^[A-Z]{2}[A-Z0-9]{20}$";
            Match mat = Regex.Match(input, pattern);
            string all = input.Substring(4) + input.Substring(0, 4);
            StringBuilder sb = new StringBuilder();



            if (mat.Success)
            {

                foreach (char sym in all)
                {
                    if (char.IsDigit(sym))
                        sb.Append(sym);
                    else
                        sb.Append(sym - 'A' + 10);
                }
                if (BigInteger.Parse(sb.ToString()) % 97 == 1)
                    return true;
                else
                    return false;
            }
            else
                return false;

        }

    }
}
