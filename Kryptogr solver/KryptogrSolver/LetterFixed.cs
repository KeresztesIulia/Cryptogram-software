using System;
using System.Drawing;
using System.Windows.Forms;

namespace KryptogrSolver
{
    class LetterFixed : Label
    {
        private readonly bool clickable;
        private char letter;
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

        

        public LetterFixed(Font font, bool click, Color color, int index): this(font, click, color, index, ' ')
        {
        }

        public LetterFixed(Font font, bool click, Color color, int index, char letter)
        {
            Letter = letter;
            Font = font;
            AutoSize = true;
            ForeColor = color;
            clickable = click;
            this.index = index;
            Click += OnClick;
        }

        public void OnClick(object sender, EventArgs e)
        {
            if (clickable)
            {
                Store.ActiveIndex = index;
            }
        }
    }
}
