using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberSecurityBot
{
    internal class ResponseHandler
    {
        // This method generates a response based on the user's input, their name, and the bot's name.
        public static string GetResponse(string input, string userName, string botName)
        {
            // Convert input to lowercase for case-insensitive matching and trim whitespace
            string lower = input.ToLower().Trim();

            // ---- Greetings and general questions ----
            if (lower.Contains("how are you") || lower.Contains("how r you"))
                return $"I am running at full security capacity, {userName}! " +
                       "How can I help you stay safe online today?";

            if (lower.Contains("your name") || lower.Contains("who are you"))
                return $"I am {botName}, your Cybersecurity Awareness Assistant, " +
                       "deployed by the Department of Cybersecurity to help South Africans stay safe online.";

            if (lower.Contains("purpose") || lower.Contains("what can you do") || lower.Contains("what can i ask"))
                return "My purpose is to educate you on cybersecurity threats. " +
                       "I can help you with: passwords, phishing, safe browsing, malware, " +
                       "social engineering, and two-factor authentication. Type 'help' for the full list.";

            if (lower.Contains("thank"))
                return $"You are welcome, {userName}! Staying informed is the best defence against cybercrime.";

            if (lower.Contains("hello") || lower.Contains("hi ") || lower == "hi")
                return $"Hello again, {userName}! What cybersecurity topic would you like to learn about?";

            // ---- Password safety ----

            if (lower.Contains("password"))
                return PasswordResponse();

            // ---- Phishing ----
            if (lower.Contains("phish"))
                return PhishingResponse();

            // ---- Safe browsing ----
            if (lower.Contains("brows") || lower.Contains("safe") || lower.Contains("internet") || lower.Contains("website"))
                return SafeBrowsingResponse();

            // ---- Malware ----
            if (lower.Contains("malware") || lower.Contains("virus") || lower.Contains("ransomware") || lower.Contains("spyware"))
                return MalwareResponse();

            // ---- Social engineering ----
            if (lower.Contains("social engineer") || lower.Contains("manipulat") || lower.Contains("pretexting"))
                return SocialEngineeringResponse();

            // ---- Two-factor authentication ----
            if (lower.Contains("2fa") || lower.Contains("two factor") || lower.Contains("two-factor") ||
                lower.Contains("authentication") || lower.Contains("otp"))
                return TwoFactorResponse();

            // ---- Default fallback ----
            
            return $"I am not sure I understand that, {userName}. " +
                   "Try asking me about passwords, phishing, malware, safe browsing, " +
                   "social engineering, or two-factor authentication. " +
                   "Or type 'help' to see all topics.";
        }

        public static string PasswordResponse()
        {
            return "Here are key password safety tips:\n\n" +
                   "  1. Use at least 12 characters - longer is stronger.\n" +
                   "  2. Mix uppercase, lowercase, numbers and symbols.\n" +
                   "     Example: MyD0g!sC@lledBob2024\n" +
                   "  3. Never reuse the same password on multiple sites.\n" +
                   "     If one site is breached, all your accounts are at risk.\n" +
                   "  4. Use a password manager like Bitwarden or 1Password\n" +
                   "     to generate and store strong passwords for you.\n" +
                   "  5. Never share your password with anyone - including IT support.\n" +
                   "  6. Change your password immediately if you suspect a breach.";
        }

        private static string PhishingResponse()
        {
            return "Phishing is one of the most common cyberattacks in South Africa.\n\n" +
                   "  What is phishing?\n" +
                   "  Criminals send fake emails or SMS messages pretending to be\n" +
                   "  your bank, SARS, or a trusted company to steal your details.\n\n" +
                   "  How to spot a phishing attempt:\n" +
                   "  1. Check the sender's email address carefully.\n" +
                   "     'support@fnb-secure.co.za' is NOT the real FNB.\n" +
                   "  2. Hover over links before clicking - does the URL look strange?\n" +
                   "  3. Be suspicious of urgent language: 'Act NOW or your account\n" +
                   "     will be closed!' is a classic phishing tactic.\n" +
                   "  4. Real banks and companies will NEVER ask for your password\n" +
                   "     or OTP via email or SMS.\n" +
                   "  5. When in doubt, go directly to the company's official website\n" +
                   "     by typing the URL yourself - do NOT click the link.";
        }

        private static string SafeBrowsingResponse()
        {
            return "Safe browsing habits protect you from many online threats.\n\n" +
                  "  Key rules:\n" +
                  "  1. Only visit sites that start with https:// (the 's' = secure).\n" +
                  "     Look for the padlock icon in your browser's address bar.\n" +
                  "  2. Avoid using public Wi-Fi (airports, cafes) for banking\n" +
                  "     or entering personal information.\n" +
                  "  3. Use a VPN on public networks to encrypt your connection.\n" +
                  "  4. Keep your browser updated - updates patch security holes.\n" +
                  "  5. Use a browser extension like uBlock Origin to block\n" +
                  "     malicious ads that can install malware.\n" +
                  "  6. Never download files from websites you do not trust.\n" +
                  "  7. Clear your browser cache and cookies regularly.";
        }

        private static string MalwareResponse()
        {
            return "Malware is malicious software designed to damage or steal from you.\n\n" +
                  "  Common types:\n" +
                  "  - Virus:      spreads by attaching itself to files.\n" +
                  "  - Ransomware: locks your files and demands payment to unlock them.\n" +
                  "  - Spyware:    secretly monitors your activity and steals data.\n" +
                  "  - Trojan:     disguises itself as legitimate software.\n\n" +
                  "  How to protect yourself:\n" +
                  "  1. Install reputable antivirus software and keep it updated.\n" +
                  "  2. Never open email attachments from unknown senders.\n" +
                  "  3. Only download software from official sources.\n" +
                  "  4. Back up your important files regularly (offline or cloud).\n" +
                  "     If ransomware strikes, you won't lose everything.\n" +
                  "  5. Keep your operating system and apps updated.";
        }

        private static string SocialEngineeringResponse()
        {
            return "Social engineering is when criminals manipulate PEOPLE rather\n" +
                   "than hacking technology.\n\n" +
                   "  Common tactics:\n" +
                   "  - Pretexting:  creating a fake scenario to gain your trust.\n" +
                   "    Example: 'I am from IT support, I need your password to fix\n" +
                   "    a critical problem on your account.'\n" +
                   "  - Baiting:     leaving a USB drive labelled 'Salaries 2024'\n" +
                   "    in a car park, hoping someone plugs it in.\n" +
                   "  - Vishing:     voice phishing - scam phone calls.\n\n" +
                   "  How to protect yourself:\n" +
                   "  1. Always verify a person's identity before sharing information.\n" +
                   "  2. Never give out passwords or personal info over the phone.\n" +
                   "  3. Legitimate IT staff will NEVER ask for your password.\n" +
                   "  4. Trust your instincts - if something feels wrong, it probably is.";
        }

        private static string TwoFactorResponse()
        {
            return "Two-Factor Authentication (2FA) adds a second layer of security.\n\n" +
                   "  How it works:\n" +
                   "  Instead of just a password, you need TWO things to log in:\n" +
                   "  1. Something you KNOW  - your password.\n" +
                   "  2. Something you HAVE  - a one-time code sent to your phone\n" +
                   "     or generated by an app like Google Authenticator.\n\n" +
                   "  Why is 2FA so important?\n" +
                   "  Even if a criminal steals your password, they cannot log in\n" +
                   "  without also having your phone. This stops most breaches.\n\n" +
                   "  How to set it up:\n" +
                   "  1. Go to security settings on any major account (Gmail, banking).\n" +
                   "  2. Enable 2FA or Two-Step Verification.\n" +
                   "  3. Use an authenticator app rather than SMS for better security.\n" +
                   "     Recommended apps: Google Authenticator, Microsoft Authenticator.";
        }  


    }
}
