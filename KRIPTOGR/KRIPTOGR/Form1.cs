using System;
using System.Windows.Forms;
using System.IO;

namespace KRIPTOGR_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.MaxLength = int.MaxValue;
            textBox2.MaxLength = int.MaxValue;
        }

        private char[] Randomize()
        {
            bool[] used = new bool[35];
            for (int i = 0; i < used.Length; i++)
            {
                used[i] = false;
            }
            char[] ABC = new char[35];
            long seed = DateTime.Now.ToFileTimeUtc();
            Random rand = new Random((int)seed);
            for(int i = 0; i<ABC.Length; i++)
            {
                int index;
                do
                {
                    
                    index = rand.Next(0, 35);
                } while (used[index] || i == index);
                used[index] = true;
                ABC[i] = IndexToLetter(index);
            }    
            return ABC;
        }
        private string Convert(string textToConvert)
        {
            char[] newABC = Randomize();
            int textLength = textToConvert.Length;
            char[] newText = textToConvert.ToCharArray();

            for (int i = 0; i < textLength; i++)
            {
                int charIndex = LetterToIndex(newText[i]);
                if(charIndex != -1)
                {
                    newText[i] = newABC[charIndex];
                }
            }
            return new string(newText);
        }

        private int LetterToIndex(char chara)
        {
            if(chara >= 'a' && chara <= 'z')
            {
                return chara - 97;
            }
            else if (chara >= 'A' && chara <= 'Z')
            {
                return chara - 65;
            }
            else if(chara == 'á' || chara == 'Á')
            {
                return 26;
            }
            else if(chara == 'é' || chara == 'É')
            {
                return 27;
            }
            else if(chara == 'í' || chara == 'Í')
            {
                return 28;
            }
            else if(chara == 'ó' || chara == 'Ó')
            {
                return 29;
            }
            else if(chara == 'ö' || chara == 'Ö')
            {
                return 30;
            }
            else if(chara == 'ő' || chara == 'Ő')
            {
                return 31;
            }
            else if(chara == 'ú' || chara == 'Ú')
            {
                return 32;
            }
            else if (chara == 'ü' || chara == 'Ü')
            {
                return 33;
            }
            else if(chara == 'ű' || chara == 'Ű')
            {
                return 34;
            }
            else
            {
                return -1;
            }

        }
        private char IndexToLetter(int index)
        {
            if(index<=25)
            {
                return (char)(index + 65);
            }
            else if (index == 26)
            {
                return 'Á';
            }
            else if (index == 27)
            {
                return 'É';
            }
            else if (index == 28)
            {
                return 'Í';
            }
            else if (index == 29)
            {
                return 'Ó';
            }
            else if (index == 30)
            {
                return 'Ö';
            }
            else if (index == 31)
            {
                return 'Ő';
            }
            else if (index == 32)
            {
                return 'Ú';
            }
            else if (index == 33)
            {
                return 'Ü';
            }
            else if (index == 34)
            {
                return 'Ű';
            }
            return '\n';
        }

        private void CryptoClick(object sender, EventArgs e)
        {
           textBox2.Text = Convert(textBox1.Text);
            Save();
            button2.Enabled = false;
        }

        private void Save()
        {
            File.WriteAllText("save.txt", textBox1.Text + "§" + textBox2.Text);
        }

        private void Load(object sender, EventArgs e)
        {
            if(File.Exists("save.txt"))
            {
                TextReader load = File.OpenText("save.txt");
                string text = load.ReadToEnd();
                string[] texts = text.Split('§');
                textBox1.Text = texts[0];
                textBox2.Text = texts[1];
                load.Close();
            }
            

        }
    }
}
