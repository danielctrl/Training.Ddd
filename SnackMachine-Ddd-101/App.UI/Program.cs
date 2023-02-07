namespace App.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var snackMachineViewModel = new SnackMachineViewModel();
            var renderer = new SnackMachineTextualRenderer(snackMachineViewModel);

            while (true)
            {
                Console.Clear();
                Console.Write(renderer.Render());

                var commandKey = Console.ReadKey();
                while(!snackMachineViewModel.ValidateCommand(commandKey))
                {
                    Console.WriteLine("Invalid command, try again.");
                    commandKey = Console.ReadKey();
                }

                snackMachineViewModel.ExecuteCommand(commandKey);
            }
        }
    }
}