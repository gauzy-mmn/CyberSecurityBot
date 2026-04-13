using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class InputValidator
    {
        public static bool isValid(string input)
        {
            // Check for null, empty, or whitespace-only input
            if (string.IsNullOrWhiteSpace(input))
                return false;

            // A valid input must have at least 2 characters (after trimming)
            // trimming is important to ensure that inputs like "  " are not considered valid
            if (input.Trim().Length < 2)
                return false;

            return true; // Input passed all checks
        }

        public static bool isNameValid(string name)
        {
            // First, run the standard isValid check
            if (!isValid(name))
                return false;

            // A name must have at least 2 characters
            if (name.Trim().Length < 2)
                return false;

            // Reject names that are numeric (e.g., "12345")
            if (int.TryParse(name.Trim(), out _))
                return false;

            return true; //Name passed all checks
        }
        // A method to sanitise input by trimming whitespace and converting to lowercase
        public static string Sanitise(string input)
        {

            return input.Trim().ToLower();
        }


    }
}