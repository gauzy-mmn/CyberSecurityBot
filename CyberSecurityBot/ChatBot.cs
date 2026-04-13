using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Media;   // Needed for SoundPlayer (voice greeting)
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CyberSecurityBot
{
    //
    internal class ChatBot
    {
        //
        public string BotName { get; private set; } // The chatbot's name
        public string UserName { get; set; }// The user's name
        public string Version { get; private set; } // The chatbot's version

        // Constructor initializes the chatbot's name, version, and sets the user's name to an empty string.
        public ChatBot()
        {
            BotName = "CyberSecBot"; // Set the chatbot's name
            UserName = "";// Initialize the user's name as an empty string
            Version = "1.0";// Set the chatbot's version
        }

        // This method starts the chatbot by playing a voice greeting, displaying the logo, greeting the user, and entering the conversation loop.
        public void Start()
        {
            PlayVoiceGreeting();
            DisplayLogo();
            Greet();
            RunConversationLoop();

        }


        // This method plays a voice greeting using a .wav file. It uses the SoundPlayer class from System.Media.
        private void PlayVoiceGreeting()
        {

            try
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.PlaySync();
            }
            catch (Exception)
            {

            }
        }

        // This method displays an ASCII art logo and some introductory text about the chatbot. It uses different console colors for styling.
        private void DisplayLogo()
        {
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(@"
  ██████╗██╗   ██╗██████╗ ███████╗██████╗
 ██╔════╝╚██╗ ██╔╝██╔══██╗██╔════╝██╔══██╗
 ██║      ╚████╔╝ ██████╔╝█████╗  ██████╔╝
 ██║       ╚██╔╝  ██╔══██╗██╔══╝  ██╔══██╗
 ╚██████╗   ██║   ██████╔╝███████╗██║  ██║
  ╚═════╝   ╚═╝   ╚═════╝ ╚══════╝╚═╝  ╚═╝");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("  ╔══════════════════════════════════════════════════════════════╗");
                Console.WriteLine("  ║        CYBERSECURITY AWARENESS BOT  v" + Version + "         ║");
                Console.WriteLine("  ║        Keeping South Africa Safe Online                      ║");
                Console.WriteLine("  ╚══════════════════════════════════════════════════════════════╝");
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        private void Greet()
        {
            DisplayDivider();
            Console.ForegroundColor = ConsoleColor.Yellow;
            TypeText("  Welcome! Before we begin, what is your name? ");
            Console.ResetColor();

            // Keep asking until a valid name is entered
            string input = Console.ReadLine();
            while (!InputValidator.IsValidName(input))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                TypeText("  Please enter a valid name to continue: ");
                Console.ResetColor();
                input = Console.ReadLine();
            }

            UserName = input.Trim(); // Trim removes leading/trailing spaces

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            TypeText($"  Hello, {UserName}! I am {BotName}, your Cybersecurity Awareness Assistant.");
            Console.WriteLine();
            TypeText("  I am here to help you stay safe online.");
            Console.WriteLine();
            Console.ResetColor();

            DisplayDivider();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine("  You can ask me about:");
            Console.WriteLine("   - passwords         (e.g. 'How do I make a strong password?')");
            Console.WriteLine("   - phishing           (e.g. 'What is phishing?')");
            Console.WriteLine("   - safe browsing      (e.g. 'How do I browse safely?')");
            Console.WriteLine("   - malware            (e.g. 'What is malware?')");
            Console.WriteLine("   - social engineering (e.g. 'What is social engineering?')");
            Console.WriteLine("   - 2fa                (e.g. 'What is two-factor authentication?')");
            Console.WriteLine();
            Console.WriteLine("  Type 'help' to see topics again, or 'exit' to quit.");
            Console.WriteLine();
            Console.ResetColor();

            DisplayDivider();

        }

        public void RunConversationLoop()
        {
            while (true) // Loop runs forever until "break" is called
            {
                // Show the user's name as a prompt
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"  {UserName}: ");
                Console.ResetColor();

                string input = Console.ReadLine();

                // --- Input Validation ---
                // Check if input is empty or just whitespace
                if (!InputValidator.IsValid(input))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    TypeText($"\n  {BotName}: I didn't catch that. Could you rephrase?\n");
                    Console.ResetColor();
                    continue; // Skip to next loop cycle
                }

                // --- Exit Command ---
                if (input.Trim().ToLower() == "exit")
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    DisplayDivider();
                    TypeText($"  {BotName}: Stay safe online, {UserName}. Goodbye!");
                    Console.WriteLine();
                    DisplayDivider();
                    Console.ResetColor();
                    break; // Exit the while loop and end the program
                }

                // --- Help Command ---
                if (input.Trim().ToLower() == "help")
                {
                    ShowHelp();
                    continue;
                }

                // --- Get and display a response ---
                string response = ResponseHandler.GetResponse(input, UserName, BotName);

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"  {BotName}: ");
                Console.ResetColor();
                TypeText(response); // Typing effect for bot response
                Console.WriteLine();
                Console.WriteLine();
                DisplayDivider();
            }
        }

        private void ShowHelp()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("  Topics I can help with:");
            Console.WriteLine("   - passwords          - phishing");
            Console.WriteLine("   - safe browsing      - malware");
            Console.WriteLine("   - social engineering - 2fa");
            Console.WriteLine("   - how are you        - what is your purpose");
            Console.WriteLine();
            Console.ResetColor();
        }

        // This method simulates a typing effect by printing one character at a time with a short delay.
        private void TypeText(string text)
        {
            foreach (char c in text) // Loop through every character
            {
                Console.Write(c);         // Print one character
                Thread.Sleep(18);         // Wait 18 milliseconds
            }
            Console.WriteLine();
        }

        // This method displays a horizontal divider line in the console for better readability.
        private void DisplayDivider()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ────────────────────────────────────────────────────────────────");
            Console.ResetColor();
        }

    }
}
