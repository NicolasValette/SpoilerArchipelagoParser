
namespace NoNiDev.ApplicationConsoleReader
{
    internal static class UserReader
    {
        public static bool GetUserAnswer()
        {

            do
            {
                Console.WriteLine("Y/N ?");
                var key = Console.ReadKey();
                Console.WriteLine();
                if (key.Key == ConsoleKey.Y)
                    return true;
                else if (key.Key == ConsoleKey.N)
                    return false;
                Console.WriteLine("Incorrect key pressed");
            } while (true);
        }
    }
}
