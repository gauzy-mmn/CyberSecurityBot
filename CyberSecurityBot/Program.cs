using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Calls the ChatBot class to start the chatbot session
           
            ChatBot bot = new ChatBot();

            bot.Start();// Starts the chatbot session

        }
    }
}
