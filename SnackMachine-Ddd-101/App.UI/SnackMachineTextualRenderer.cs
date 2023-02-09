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
            return RenderCustomerRelatedInfo()
                .AppendLine().AppendLine()
                .Append(RenderAdministrativeInfo());
        }

        private StringBuilder RenderCustomerRelatedInfo()
        {
            var strBuilder = new StringBuilder();

            return strBuilder
                .AppendLine($"{SnackMachineViewModel.CommandBuyASnackId.Key}) Buy Snack")
                .AppendLine($"{SnackMachineViewModel.CommandInsert1CentId.Key}) Insert ¢1")
                .AppendLine($"{SnackMachineViewModel.CommandInsert10CentsId.Key}) Insert ¢10")
                .AppendLine($"{SnackMachineViewModel.CommandInsert25CentsId.Key}) Insert ¢25")
                .AppendLine($"{SnackMachineViewModel.CommandInsert1DollarId.Key}) Insert $1")
                .AppendLine($"{SnackMachineViewModel.CommandInsert5DollarsId.Key}) Insert $5")
                .AppendLine($"{SnackMachineViewModel.CommandInsert20DollarsId.Key}) Insert $20")
                .AppendLine()
                .AppendLine($"Money Inserted: <<{_snackMachineViewModel.MoneyInTransaction}>>");
        }

        private StringBuilder RenderAdministrativeInfo()
        {
            var strBuilder = new StringBuilder();

            return strBuilder
                .AppendLine("Administrative data ...")
                .AppendLine($"{_snackMachineViewModel.MoneyInside.OneCentCount}x ¢1")
                .AppendLine($"{_snackMachineViewModel.MoneyInside.TenCentCount}x ¢10")
                .AppendLine($"{_snackMachineViewModel.MoneyInside.QuarterCount}x ¢25")
                .AppendLine($"{_snackMachineViewModel.MoneyInside.OneDollarCount}x $1")
                .AppendLine($"{_snackMachineViewModel.MoneyInside.FiveDollarCount}x $5")
                .AppendLine($"{_snackMachineViewModel.MoneyInside.TwentyDollarCount}x $20")
                .AppendLine($"Money inside <<{_snackMachineViewModel.MoneyInside}>>");
        }
    }
}