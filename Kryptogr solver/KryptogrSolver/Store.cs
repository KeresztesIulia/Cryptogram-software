
namespace KryptogrSolver
{
    static class Store
    {
        private static int activeIndex = -1;
        public static bool performSelections = true;
        public static Form1 form;
        public static int ActiveIndex
        {
            get
            {
                return activeIndex;
            }
            set
            {
                if(performSelections)
                {
                    if (activeIndex == value)
                    {
                        form.DeselectLetters(activeIndex);
                        activeIndex = -1;
                    }
                    else
                    {
                        if (activeIndex != -1)
                        {
                            form.DeselectLetters(activeIndex);
                        }
                        if (activeIndex == -1 || activeIndex != value)
                        {
                            form.SelectLetters(value);
                        }
                        activeIndex = value;
                    }
                }
            }
        }
    }
}
