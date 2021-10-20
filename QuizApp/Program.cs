using System;

namespace QuizApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            do
            {
                menu.Entrance();
            } while (true);
        }
    }
}
