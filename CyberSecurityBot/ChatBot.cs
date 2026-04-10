using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;   // Needed for SoundPlayer (voice greeting)
using System.Threading;

namespace CyberSecurityBot
{
    internal class ChatBot
    {
        public string BotName { get; private set; } // The chatbot's name
        public string UserName { get; set; }// The user's name
        public string Version { get; private set; } // The chatbot's version
        
        
        public ChatBot()
        {
            BotName = "CyberSecBot"; // Set the chatbot's name
            UserName = "";// Initialize the user's name as an empty string
            Version = "1.0";// Set the chatbot's version
        }

        public void Start()
        {
            PlayVoiceGreeting();
            DisplayLogo();
            Greet();

        }
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
        
        private void DisplayLogo()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("  ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("  ║        CYBERSECURITY AWARENESS BOT  v" + Version + "         ║");
            Console.WriteLine("  ║        Keeping South Africa Safe Online                      ║");
            Console.WriteLine("  ╚══════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        private void Greet()
        {
           

        }



    }
}
