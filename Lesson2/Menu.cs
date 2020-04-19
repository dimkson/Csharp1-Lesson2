using System;

namespace MenuClass
{
    class Menu
    {
        public delegate void delMenu();
        private delMenu[] delMenus;

        public Menu(delMenu[] delegates)
        {
            delMenus = delegates;
        }

        public void ChooseMenu()
        {
            int num;
            do
            {
                num = 1 ;
                Console.WriteLine($"Для выбора задания введите номер задания от 1 до {delMenus.Length}");
                foreach (delMenu del in delMenus)
                {
                    Console.WriteLine(num++ + " - " + del.Method.Name);
                }
                Console.WriteLine("Для выхода из меню нажмите 10");
                try
                {
                    Int32.TryParse(Console.ReadLine(), out num);
                    delMenus[num - 1]();
                    Console.Clear();
                }
                catch (IndexOutOfRangeException e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (num != 10);
        }
    }

    static class FastConsole
    {
        public static void Input(string str, out int num)
        {
            Console.WriteLine(str);
            Int32.TryParse(Console.ReadLine(), out num);
        }
        public static void Input(string str, out double num)
        {
            Console.WriteLine(str);
            double.TryParse(Console.ReadLine(), out num);
        }
        public static string Input(string str)
        {
            Console.WriteLine(str);
            return Console.ReadLine();
        }
        public static void Pause()
        {
            Console.ReadLine();
        }
        public static void Print(string str, int x, int y)
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.WriteLine(str);
        }
    }
}
