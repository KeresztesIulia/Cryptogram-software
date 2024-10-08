using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KryptogrSolver
{
    // class for guessing the original letter of the text
    // generally clickable, except for the puctuation signs
    class LetterGuess : Label
    {
        private readonly bool clickable;
        private char letter;
        private const char defaultValue = ' ';
        private readonly int index;

        public char Letter
        {
            set
            {
                letter = value;
                Text = value + "";
            }
            get
            {
                return letter;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
        }

        public bool IsEmpty
        {
            get
            {
                return (letter == defaultValue);
            }
        }

        public LetterGuess(Font font, bool click, Color color, int index) : this(font, click, color, index, ' ') { }

        public LetterGuess(Font font, bool click, Color color, int index, char letter)
        {
            Letter = letter;
            Font = font;
            clickable = click;
            AutoSize = true;
            ForeColor = color;
            Click += OnClick;
            this.index = index;
        }

        public void ChangeLetter(char letter)
        {
            Letter = letter;
        }

        public void SelectChange(Color bgColor, Color fontColor) //select, selectactive and unselect
        {
            BackColor = bgColor;
            ForeColor = fontColor;
        }

        public void OnClick(object sender, EventArgs e)
        {
            if(clickable)
            {
                Store.ActiveIndex = index;
            }
        }
    }
}
