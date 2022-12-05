using Final.Common;

namespace Final.Cli
{
    internal class ConsoleInput : InputAPI
    {
        public event EventHandler<string> InputTaken;

        public void TakeInput()
        {
            string input = Console.ReadLine();
            InputTaken?.Invoke(this, input);
        }
    }
}
