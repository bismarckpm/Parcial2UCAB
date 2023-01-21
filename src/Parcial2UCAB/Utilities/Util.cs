using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Parcial2UCAB.Utilities
{
    using System.Text.RegularExpressions;
    using System.Text;

    public static class Util
    {
        private static readonly Regex EmailRegex = new Regex(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");

        public static bool IsValidEmail(string email)
        {
            return EmailRegex.IsMatch(email?.Trim());
        }

        public static string Ajustar(string palabra)
        {
            if (string.IsNullOrWhiteSpace(palabra) || palabra == "\n")
            {
                return string.Empty;
            }

            var adjustedWord = new StringBuilder();
            var wordLength = palabra.Length;
            var lastCharWasNewLine = false;

            for (int i = 0; i < wordLength; i++)
            {
                var currentChar = palabra[i];

                if (char.IsWhiteSpace(currentChar) || currentChar == '\n')
                {
                    if (lastCharWasNewLine)
                    {
                        continue;
                    }

                    lastCharWasNewLine = true;
                }
                else
                {
                    lastCharWasNewLine = false;
                    adjustedWord.Append(currentChar);
                }
            }

            if (!lastCharWasNewLine)
            {
                adjustedWord.Append("\n");
            }

            return adjustedWord.ToString();
        }


    }

}
