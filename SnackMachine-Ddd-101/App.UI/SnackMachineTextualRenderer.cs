using System.Text;

namespace App.UI
{
    public class SnackMachineTextualRenderer
    {
        private SnackMachineViewModel _snackMachineViewModel {get; }

        public SnackMachineTextualRenderer(SnackMachineViewModel snackMachineViewModel)
        {
            _snackMachineViewModel = snackMachineViewModel;
        }

        public StringBuilder Render()
        {
            return RenderUserCommands()
                .AppendLine()
                .Append(RenderAdministrativeInfo());
        }

        private StringBuilder RenderUserCommands()
        {
            var strBuilder = new StringBuilder();

            return strBuilder
                .AppendLine($"{SnackMachineViewModel.CommandInsert1CentId.Key}) Insert ₵1")
                .AppendLine($"Money inserted: <<{_snackMachineViewModel.MoneyInTransaction}>>");
        }

        private StringBuilder RenderAdministrativeInfo()
        {
            var strBuilder = new StringBuilder();

            return strBuilder
                .AppendLine("admin ...")
                .AppendLine($"Money inside <<{00}>>");
        }
    }

    /*
    User Commands
        How to use ....

        1: Buy a snack
        2: Put ₵1
        3: Put ₵10
        4: Put ₵25
        5: Put $1
        6: Put $5
        7: Put $20
        8: Return Money
        
        Money Inserted: $10.25 or ₵45

    Administrative Info
        Money Inside: $10.25 or ₵45
        8x ₵1
        8x ₵10
        8x ₵25
        8x $1
        8x $5
        8x $20
    */
}