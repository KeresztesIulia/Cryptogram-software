

namespace KryptogrSolver
{
    static class LetterIndexConvert
    {
        public static int LetterToIndex(char character)
        {
            if (character >= 'a' && character <= 'z')
            {
                return character - 97;
            }
            else if (character >= 'A' && character <= 'Z')
            {
                return character - 65;
            }
            else if (character == 'á' || character == 'Á')
            {
                return 26;
            }
            else if (character == 'é' || character == 'É')
            {
                return 27;
            }
            else if (character == 'í' || character == 'Í')
            {
                return 28;
            }
            else if (character == 'ó' || character == 'Ó')
            {
                return 29;
            }
            else if (character == 'ö' || character == 'Ö')
            {
                return 30;
            }
            else if (character == 'ő' || character == 'Ő')
            {
                return 31;
            }
            else if (character == 'ú' || character == 'Ú')
            {
                return 32;
            }
            else if (character == 'ü' || character == 'Ü')
            {
                return 33;
            }
            else if (character == 'ű' || character == 'Ű')
            {
                return 34;
            }
            else
            {
                return -1;
            }
           
          
        }
       
        public static char IndexToLetter(int index)
        {
            if (index <= 25)
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

        public static char KeyValueToLetter(int value)
        {
            if(value>=65 && value<=90)
            {
                return (char)value;
            }
            switch(value)
            {
                case 48:
                    return 'Í';
                case 186:
                    return 'É';
                case 187:
                    return 'Ó';
                case 189:
                    return 'Ü';
                case 192:
                    return 'Ö';
                case 219:
                    return 'Ő';
                case 220:
                    return 'Ű';
                case 221:
                    return 'Ú';
                case 222:
                    return 'Á';
                case 32:
                case 8:
                case 46:
                case 27:
                    return ' ';
            }
            return '\n';
        }
    }
}
