using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Cipher
{
    internal class VigenerHelper
    {
        private List<char> alphabet = null;
        private int size = 0;
        private List<List<char>> body = null;
        private string alphabetUkr = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";
        private string alphabetEng = "abcdefghijklmonpqrstvwuyxz";

        private void initBody()
        {
            int shift = 0;

            for (int i = 0; i < size; i++)
            {
                body.Add(new List<char>());

                for (int j = 0; j < size; j++)
                {
                    int index = j + shift;

                    if (index >= size)
                    {
                        index = Math.Abs((j + shift) - size);
                    }

                    body[i].Add(alphabet[index]);
                }

                shift++;
            }
        }

        public VigenerHelper()
        {
            alphabet = new List<char>();
            body = new List<List<char>>();
            alphabet.AddRange(alphabetUkr);
            size = alphabet.Count;
            initBody();
        }

        public bool changeAlphabet(string type)
        {
            alphabet.Clear();
            body.Clear();

            if (type == "Eng")
            {
                alphabet.AddRange(alphabetEng);
            } else if (type == "Ukr")
            {
                alphabet.AddRange(alphabetUkr);
            } else
            {
                return false;
            }

            size = alphabet.Count;
            initBody();

            return true;
        }

        public string getCipher(string text, string key)
        {
            int keyPosition = 0;
            string cipher = "";

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] != ' ' && text[i] != ',' && text[i] != '.')
                {
                    int x = alphabet.IndexOf(text[i]);
                    int y = alphabet.IndexOf(key[keyPosition]);

                    cipher += body[x][y];

                    keyPosition++;

                    if (keyPosition >= key.Length)
                    {
                        keyPosition = 0;
                    }
                }
                else
                {
                    cipher += text[i];
                }

            }

            return cipher;
        }

        public string getText(string cipher, string key)
        {
            int keyPosition = 0;
            string text = "";

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] != ' ' && cipher[i] != ',' && cipher[i] != '.')
                {
                    int x = alphabet.IndexOf(key[keyPosition]);
                    int y = body[x].IndexOf(cipher[i]);

                    text += alphabet[y];

                    keyPosition++;

                    if (keyPosition >= key.Length)
                    {
                        keyPosition = 0;
                    }
                }
                else
                {
                    text += cipher[i];
                }

            }

            return text;
        }
    }
}
