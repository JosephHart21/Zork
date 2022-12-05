using Final.Common;

namespace Final.Cli
{
    internal class ConsoleOutput : OutputAPI
    {
        public void Write(object obj)
        {
            Console.Write(obj);
        }

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(object obj)
        {
            Console.WriteLine(obj);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }

    }

}
