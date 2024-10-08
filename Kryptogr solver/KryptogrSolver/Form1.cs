using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptogrSolver
{
    public partial class Form1 : Form
    {
        bool seeCryptoEnter = true;

        static string fontName = "NSimSun";
        static int fontSize = 20;
        Font baseCryptoFont = new Font(fontName, fontSize, FontStyle.Bold, GraphicsUnit.Pixel);
        Font baseGuessFont = new Font(fontName, fontSize, FontStyle.Underline|FontStyle.Bold, GraphicsUnit.Pixel);

        Color baseFixedColor = Color.DarkKhaki;
        Color baseGuessColor = Color.Goldenrod;
        Color selectedFixedColor = Color.Orange;
        Color selectedGuessColor = Color.Gold;
        Color baseBackgroundColor = Color.Transparent;
        Color selectedBackgroundColorActive = Color.Chocolate;
        Color selectedBackgroundColorInactive = Color.DarkGoldenrod;

        int maxLettersInALine;
        readonly int horizontalMultiplier;
        readonly int verticalMultiplier;

        LetterFixed[] fixedLetters;
        LetterGuess[] guessLetters;

        List<int>[] letterList = new List<int>[35];

        char[] fullCryptoText;
        int textLength;

        public Form1()
        {
            InitializeComponent();
            horizontalMultiplier = fontSize + 2;
            verticalMultiplier = (int)(fontSize * 1.6);
            maxLettersInALine = (kryptoTextSpace.Width - 15) / horizontalMultiplier;
            Store.form = this;
        }


        /// <summary>
        /// Generates crypto view from text, if there's anything in the textbox. Shows textbox if it's not visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cryptofy(object sender, EventArgs e)
        {

            fullCryptoText = cryptoTextEnter.Text.ToCharArray();
            textLength = fullCryptoText.Length;

            if (!seeCryptoEnter)
            {
                cryptoTextEnter.Visible = true;
                seeCryptoEnter = true;
                Store.performSelections = false;
                Store.ActiveIndex = -1;
                Store.performSelections = true;
                
            }
            else if(seeCryptoEnter && cryptoTextEnter.Text == "")
            {
                seeCryptoEnter = false;
                cryptoTextEnter.Visible = false;
            }
            else
            {
                //reset values
                ResetLabels();
                ResetLists();

                //generate letterfixed and letterguess
                //add them to letterlist                     
                //  - combined. Not the best but I don't want to go throughthe labels twice
                GenerateLabels();


                cryptoTextEnter.Text = "";

                //hide TextBox
                cryptoTextEnter.Visible = false;
                seeCryptoEnter = false;
            }

        }

        private void ResetLabels()
        {
            if(guessLetters != null)
            {
                for(int i = 0; i < guessLetters.Length; i++)
                {
                    guessLetters[i].Dispose();
                    fixedLetters[i].Dispose();
                }
            }
        }
        private void ResetLists()
        {
            if (letterList != null)
            {
                for (int i = 0; i < letterList.Length; i++)
                {
                    if(letterList[i] != null)
                    {
                        letterList[i] = null;
                    }
                    
                }
            }
        }

        private void GenerateLabels()
        {
            guessLetters = new LetterGuess[textLength];
            fixedLetters = new LetterFixed[textLength];

            int xPosition = 0;
            int yPosition = 0;
            for (int i = 0; i < textLength; i++)
            {
                char letter = fullCryptoText[i];
                GenerateGuessLetter(i, letter, xPosition, yPosition);
                GenerateFixedLetter(i, letter, xPosition, yPosition);
                IndexToList(i, letter);
                xPosition++;
                if (xPosition == maxLettersInALine)
                {
                    yPosition++;
                    xPosition = 0;
                }
                else if (fullCryptoText[i] == '\n')
                {
                        yPosition++;
                        xPosition = 0;
                }
            }

        }

        private void GenerateGuessLetter(int index, char letter, int xPosition, int yPosition)
        {
            if(LetterIndexConvert.LetterToIndex(letter) == -1)
            {
                guessLetters[index] = new LetterGuess(baseCryptoFont, false, baseGuessColor, index, letter);
            }
            else
            {
                guessLetters[index] = new LetterGuess(baseGuessFont, true, baseGuessColor, index);
            }
            kryptoTextSpace.Controls.Add(guessLetters[index]);
            SetGuessPosition(guessLetters[index], xPosition, yPosition);
        }

        private void GenerateFixedLetter(int index, char letter, int xPosition, int yPosition)
        {
            if (LetterIndexConvert.LetterToIndex(letter) != -1)
            {
                fixedLetters[index] = new LetterFixed(baseCryptoFont, true, baseFixedColor, index, letter);
            }
            else
            {
                fixedLetters[index] = new LetterFixed(baseCryptoFont, false, baseFixedColor, index);
            }
            kryptoTextSpace.Controls.Add(fixedLetters[index]);
            SetFixedPosition(fixedLetters[index], xPosition, yPosition);
            
        }

        private void SetGuessPosition(LetterGuess letterLabel, int xPosition, int yPosition)
        {

            letterLabel.Location = new Point(xPosition * horizontalMultiplier, yPosition * 2 * verticalMultiplier);
        }

        private void SetFixedPosition(LetterFixed letterLabel, int xPosition, int yPosition)
        {
            letterLabel.Location = new Point(xPosition * horizontalMultiplier, fontSize + 5 + yPosition * 2 * verticalMultiplier);
        }

        private void IndexToList(int index, char letter)
        {
            int letterIndex = LetterIndexConvert.LetterToIndex(letter);
            if(letterIndex != -1)
            {
                if(letterList[letterIndex] == null)
                {
                    letterList[letterIndex] = new List<int>();
                }
                letterList[letterIndex].Add(index);
            }
        }

        public void DeselectLetters(int index)
        {
            char letter = fixedLetters[index].Letter;
            int letterIndex = LetterIndexConvert.LetterToIndex(letter);
            foreach (int labelIndex in letterList[letterIndex])
            {
                guessLetters[labelIndex].SelectChange(baseBackgroundColor, baseGuessColor);
                fixedLetters[labelIndex].ForeColor = baseFixedColor;
            }
        }
        public void SelectLetters(int index)
        {
            char letter = fixedLetters[index].Letter;
            int letterIndex = LetterIndexConvert.LetterToIndex(letter);
            foreach (int labelIndex in letterList[letterIndex])
            {
                if(labelIndex == index)
                {
                    guessLetters[labelIndex].SelectChange(selectedBackgroundColorActive, selectedGuessColor);
                }
                else
                {
                    guessLetters[labelIndex].SelectChange(selectedBackgroundColorInactive, selectedGuessColor);
                }
                fixedLetters[labelIndex].ForeColor = selectedFixedColor;
            }
        }

        private void InsertLetter(object sender, KeyEventArgs e)
        {
            if (Store.ActiveIndex != -1)
            {
                char letter = LetterIndexConvert.KeyValueToLetter(e.KeyValue);
                
                int listIndex = LetterIndexConvert.LetterToIndex(fixedLetters[Store.ActiveIndex].Letter);
                if(letter != '\n')
                {
                    foreach (int index in letterList[listIndex])
                    {
                        guessLetters[index].Letter = letter;
                    }
                    if(letter!=' ')
                    {
                        int newIndex = Store.ActiveIndex;
                        do
                        {
                            newIndex++;
                        } while (newIndex < guessLetters.Length && (guessLetters[newIndex].Letter != ' ' || fixedLetters[newIndex].Letter == ' '));
                        if (newIndex < guessLetters.Length)
                        {
                            Store.ActiveIndex = newIndex;
                        }
                    }
                    
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            maxLettersInALine = (kryptoTextSpace.Width - 15) / horizontalMultiplier;
            int xPosition = 0;
            int yPosition = 0;
            for (int i = 0; i < textLength; i++)
            {

                SetGuessPosition(guessLetters[i], xPosition, yPosition);
                SetFixedPosition(fixedLetters[i], xPosition, yPosition);
                xPosition++;
                if (xPosition == maxLettersInALine)
                {
                    yPosition++;
                    xPosition = 0;
                }
                else if (fullCryptoText[i] == '\n')
                {
                    yPosition++;
                    xPosition = 0;
                }
            }

        }
    }
}
