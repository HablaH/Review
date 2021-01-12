using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace EncryptStringHard
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(args[1]);
            string err = "use aruments: encrypt/decrypt (full path of file) a/b/c/d/e/r (r does not work for decrypt)";
            if (args.Length == 0) 
            {
                Console.WriteLine(err);
                return;
            }
            string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string inputFileName = args[1];
            string text = File.ReadAllText(inputFileName);
            Console.WriteLine(text);
            //Console.WriteLine(args[0] + " " + args[1][0]);
            if (args[0] == "encrypt")
            {
                string outputFileName = "encrypted.txt";
                using (StreamWriter sw = File.CreateText(Path.Combine(location, outputFileName)))
                {
                    sw.WriteLine(text.Encrypt(args[2][0]));
                }
            }
            else if (args[0] == "decrypt")
            {
                string outputFileName = "decrypted.txt";
                using (StreamWriter sw = File.CreateText(Path.Combine(location, outputFileName)))
                {
                    sw.WriteLine(text.Decrypt(args[2][0]));
                }
            }
            else Console.WriteLine(err);
        }
    }

    static class Encryptu
    {
        static readonly Random rnd = new Random();
        public static string Encrypt(this string text, char character) 
        {
            return EncryptWithKey(text, character);
        }

        private static string EncryptWithKey(string text, char key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] selectedCipher = ChooseArray(key);
            string encryptedString = String.Empty;
            foreach (char character in text)
            {
                if (!char.IsLetter(character))
                {
                    encryptedString += character;
                }
                else if (char.IsUpper(character))
                {
                    char[] upperAlpha = alphabet.ArrayToUpper();
                    char[] upperSelectedCipher = selectedCipher.ArrayToUpper();
                    //int index = alphabet.ToString().IndexOf(character);
                    int index = Array.IndexOf(upperAlpha, character);
                    encryptedString += upperSelectedCipher[index];
                }
                else
                {
                    int index = Array.IndexOf(alphabet, character);
                    encryptedString += selectedCipher[index];
                }
            }
            return encryptedString;
        }

        private static char[] ChooseArray(char key)
        {
            switch (key)
            {
                case 'a':
                    return new char[] {'z','y','x','w','v','u','t','s','r','q','p','o','n','m','l','k','j','i','h','g','f','e','d','c','b','a'};
                case 'b':
                    return new char[] {'n','o','p','q','r','s','t','u','v','w','x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m'};
                case 'c':
                    return new char[] {'x','y','z','a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w'};
                case 'd':
                    return new char[] {'b','a','d','c','f','e','h','g','j','i','l','k','n','m','p','o','r','q','t','s','v','u','x','w','z','y'};
                case 'e':
                    return new char[] {'z','a','y','b','x','c','w','d','v','e','u','f','t','g','s','h','r','i','q','j','p','k','o','l','n','m'};
                case 'r':
                    return RandomArray();
                default: 
                    return new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};

            }
        }

        private static char[] RandomArray()
        {
            char[] alpha = ChooseArray('f');
            char[] randomAlpha = new char[26];
            for (int i = 0; i<alpha.Length; i++)
            {
            start:
                int r = rnd.Next(0, alpha.Length);
                if (char.IsLetter(randomAlpha[r])) goto start;
                else randomAlpha[r] = alpha[i];                
            }
            return randomAlpha;
        }

        public static char[] ArrayToUpper(this char[] alpha)
        {
            char[] upperAlpha = new char[alpha.Length];
            for (int i = 0; i<alpha.Length; i++)
            {
                upperAlpha[i] = char.ToUpper(alpha[i]);
            }
            return upperAlpha;
        }
    }
    
    static class Dicryptu
    {
        public static string Decrypt(this string text, char character)
        {
            return DecryptWithKey(text, character);
        }

        private static string DecryptWithKey(string text, char key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] selectedCipher = ChooseArray(key);
            string decryptedString = String.Empty;
            foreach (char character in text)
            {
                if (!char.IsLetter(character))
                {
                    decryptedString += character;
                }
                else if (char.IsUpper(character))
                {
                    char[] upperAlpha = alphabet.ArrayToUpper();
                    char[] upperSelectedCipher = selectedCipher.ArrayToUpper();
                    //int index = alphabet.ToString().IndexOf(character);
                    int index = Array.IndexOf(upperSelectedCipher, character);
                    decryptedString += upperAlpha[index];
                }
                else
                {
                    int index = Array.IndexOf(selectedCipher, character);
                    decryptedString += alphabet[index];
                }
            }
            return decryptedString;
        }

        private static char[] ChooseArray(char key)
        {
            switch (key)
            {
                case 'a':
                    return new char[] { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a' };
                case 'b':
                    return new char[] { 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm' };
                case 'c':
                    return new char[] { 'x', 'y', 'z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w' };
                case 'd':
                    return new char[] { 'b', 'a', 'd', 'c', 'f', 'e', 'h', 'g', 'j', 'i', 'l', 'k', 'n', 'm', 'p', 'o', 'r', 'q', 't', 's', 'v', 'u', 'x', 'w', 'z', 'y' };
                case 'e':
                    return new char[] { 'z', 'a', 'y', 'b', 'x', 'c', 'w', 'd', 'v', 'e', 'u', 'f', 't', 'g', 's', 'h', 'r', 'i', 'q', 'j', 'p', 'k', 'o', 'l', 'n', 'm' };
                default:
                    return new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            }
        }
    }


}
