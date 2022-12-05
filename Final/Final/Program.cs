using System.IO;
using Final.Common;
using Newtonsoft.Json;

namespace Final.Cli
{
    static public class Program
    {
        static void Main(string[] args)
        {

            var output = new ConsoleOutput();
            var input = new ConsoleInput();

            const string contentAddress = @"..\..\..\Content\appContent.json";
            App app = JsonConvert.DeserializeObject<App>(File.ReadAllText(contentAddress));

            app.Run(input, output);

            while (app.running)
            {
                output.WriteLine("");
                app.output.Write("> ");
                input.TakeInput();

            }

            output.WriteLine("You quit the app.");

        }

    }

}
