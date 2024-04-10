using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace AgilleApi.Domain.Services.Specialize
{
    public static class ManageAccounts
    {
        public static List<string> GetParentAccounts(List<string> accounts)
        {
            // Remove trailing zeros from numbers
            for (int i = 0; i < accounts.Count; i++)
            {
                string numberStr = accounts[i];
                string newNumberStr = RemoveTrailingZeros(numberStr);
                accounts[i] = newNumberStr;
            }

            // Sort the list in descending order
            List<BigInteger> numbers = accounts.Select(BigInteger.Parse).ToList();
            numbers.Sort();
            numbers.Reverse();

            numbers = numbers.Distinct().ToList();

            // Remove numbers with a prefix that matches another number in the list
            for (int i = numbers.Count - 1; i >= 0; i--)
            {
                string numberStr = numbers[i].ToString();
                foreach (BigInteger number in numbers)
                {
                    string otherNumberStr = number.ToString();
                    if (numberStr.StartsWith(otherNumberStr) && numberStr != otherNumberStr)
                    {
                        numbers.RemoveAt(i);
                        break;
                    }
                    otherNumberStr = number.ToString()[1..];
                    if (numberStr == otherNumberStr)
                    {
                        numbers.RemoveAt(i);
                        break;
                    }
                }
            }

            //List<string> parentAccounts = EqualizeTheNumberOfDigits(numbers);

            numbers.Sort();
            var parentAccounts = numbers.Select(num => num.ToString()).ToList();
            parentAccounts = parentAccounts.Distinct().ToList();

            return parentAccounts;
        }

        private static List<string> EqualizeTheNumberOfDigits(List<BigInteger> numbers)
        {
            // Convert the list of BigInteger back to a list of strings
            List<string> parentAccounts = numbers.Select(num => num.ToString()).ToList();

            // Get the largest number in the list
            string largestNumberStr = parentAccounts[0];

            // Equalize the number of digits in the numbers in the final list
            for (int i = 1; i < parentAccounts.Count; i++)
            {
                string numberStr = parentAccounts[i];
                while (numberStr.Length < largestNumberStr.Length)
                {
                    numberStr += "0";
                }
                parentAccounts[i] = numberStr;
            }

            return parentAccounts;
        }

        private static string RemoveTrailingZeros(string numberStr)
        {
            int index = numberStr.Length - 1;
            while (index >= 0 && numberStr[index] == '0')
            {
                index--;
            }

            if (index == -1)
            {
                return "0";
            }

            return numberStr.Substring(0, index + 1);
        }
    }
}