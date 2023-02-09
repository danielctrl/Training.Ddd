using App.Logic;

namespace App.UI
{
    public class SnackMachineViewModel
    {
        private SnackMachine _snackMachine {get;}

        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandBuyASnackId = KeyValuePair.Create(1, CommandBuyASnack);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandInsert1CentId = KeyValuePair.Create(2, CommandInsert1Cent);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandInsert10CentsId = KeyValuePair.Create(3, CommandInsert10Cents);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandInsert25CentsId = KeyValuePair.Create(4, CommandInsert25Cents);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandInsert1DollarId = KeyValuePair.Create(5, CommandInsert1Dollar);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandInsert5DollarsId = KeyValuePair.Create(6, CommandInsert5Dollars);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandInsert20DollarsId = KeyValuePair.Create(7, CommandInsert20Dollars);
        public static readonly KeyValuePair<int, Action<SnackMachine>> CommandReturnMoneyId = KeyValuePair.Create(8, CommandReturnMoney);

        private static void CommandBuyASnack(SnackMachine snackMachine) => snackMachine.BuySnack();
        private static void CommandInsert1Cent(SnackMachine snackMachine) => snackMachine.InsertMoney(Money.Cent);
        private static void CommandInsert10Cents(SnackMachine snackMachine) => snackMachine.InsertMoney(Money.TenCent);
        private static void CommandInsert25Cents(SnackMachine snackMachine) => snackMachine.InsertMoney(Money.Quarter);
        private static void CommandInsert1Dollar(SnackMachine snackMachine) => snackMachine.InsertMoney(Money.Dollar);
        private static void CommandInsert5Dollars(SnackMachine snackMachine) => snackMachine.InsertMoney(Money.FiveDollar);
        private static void CommandInsert20Dollars(SnackMachine snackMachine) => snackMachine.InsertMoney(Money.TwentyDollar);
        private static void CommandReturnMoney(SnackMachine snackMachine) => snackMachine.ReturnMoney();

        public SnackMachineViewModel()
        {
            _snackMachine = new SnackMachine();
        }

        public string MoneyInTransaction => _snackMachine.MoneyInTransaction.ToString();
        public Money MoneyInside => _snackMachine.MoneyInside + _snackMachine.MoneyInTransaction;
        

        public bool ValidateCommand(ConsoleKeyInfo commandKeyInfo)
        {
            if (!int.TryParse(commandKeyInfo.KeyChar.ToString(), out var commandKey))
                return false;

            int[] commandIds = {
                CommandBuyASnackId.Key,
                CommandInsert1CentId.Key,
                CommandInsert10CentsId.Key,
                CommandInsert25CentsId.Key,
                CommandInsert1DollarId.Key,
                CommandInsert5DollarsId.Key,
                CommandInsert20DollarsId.Key,
                CommandReturnMoneyId.Key,
            };

            return commandIds.Contains(commandKey);
        }

        public void ExecuteCommand(ConsoleKeyInfo commandIdKey)
        {
            if (!int.TryParse(commandIdKey.KeyChar.ToString(), out var commandId))
                throw new InvalidOperationException("Invalid command");

            switch (commandId)
            {
                default:
                    break;
            }

            if(commandId == CommandBuyASnackId.Key) CommandBuyASnackId.Value(_snackMachine);
            else if(commandId == CommandInsert1CentId.Key) CommandInsert1CentId.Value(_snackMachine);
            else if(commandId == CommandInsert10CentsId.Key) CommandInsert10CentsId.Value(_snackMachine);
            else if(commandId == CommandInsert25CentsId.Key) CommandInsert25CentsId.Value(_snackMachine);
            else if(commandId == CommandInsert1DollarId.Key) CommandInsert1DollarId.Value(_snackMachine);
            else if(commandId == CommandInsert5DollarsId.Key) CommandInsert5DollarsId.Value(_snackMachine);
            else if(commandId == CommandInsert20DollarsId.Key) CommandInsert20DollarsId.Value(_snackMachine);
            else if(commandId == CommandReturnMoneyId.Key) CommandReturnMoneyId.Value(_snackMachine);
            else throw new InvalidOperationException("Invalid command");
        }
    }
}
