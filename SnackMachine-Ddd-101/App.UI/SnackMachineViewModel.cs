using App.Logic;

namespace App.UI
{
    public class SnackMachineViewModel
    {
        private SnackMachine _snackMachine {get;}

        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandBuyASnackId = new KeyValuePair<short, Action<SnackMachine>>(1, CommandBuyASnack);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandInsert1CentId = new KeyValuePair<short, Action<SnackMachine>>(2, CommandInsert1Cent);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandInsert10CentsId = new KeyValuePair<short, Action<SnackMachine>>(3, CommandBuyASnack);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandInsert25CentsId = new KeyValuePair<short, Action<SnackMachine>>(4, CommandBuyASnack);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandInsert1DollarId = new KeyValuePair<short, Action<SnackMachine>>(5, CommandBuyASnack);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandInsert5DollarsId = new KeyValuePair<short, Action<SnackMachine>>(6, CommandBuyASnack);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandInsert20DollarsId = new KeyValuePair<short, Action<SnackMachine>>(7, CommandBuyASnack);
        public static readonly KeyValuePair<short, Action<SnackMachine>> CommandReturnMoneyId = new KeyValuePair<short, Action<SnackMachine>>(8, CommandBuyASnack);

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
        

        public bool ValidateCommand(ConsoleKeyInfo commandKey)
        {
            if (!short.TryParse(commandKey.KeyChar.ToString(), out var commandKeyAsShort))
                return false;

            short[] commandIds = {
                CommandBuyASnackId.Key,
                CommandInsert1CentId.Key,
                CommandInsert10CentsId.Key,
                CommandInsert25CentsId.Key,
                CommandInsert1DollarId.Key,
                CommandInsert5DollarsId.Key,
                CommandInsert20DollarsId.Key,
                CommandReturnMoneyId.Key,
            };

            return commandIds.Contains(commandKeyAsShort);
        }

        public void ExecuteCommand(ConsoleKeyInfo commandKey)
        {
            if (!short.TryParse(commandKey.KeyChar.ToString(), out var commandKeyAsShort))
                throw new InvalidOperationException("Invalid command");

            if(commandKeyAsShort == CommandBuyASnackId.Key) CommandBuyASnackId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandInsert1CentId.Key) CommandInsert1CentId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandInsert10CentsId.Key) CommandInsert10CentsId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandInsert25CentsId.Key) CommandInsert25CentsId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandInsert1DollarId.Key) CommandInsert1DollarId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandInsert5DollarsId.Key) CommandInsert5DollarsId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandInsert20DollarsId.Key) CommandInsert20DollarsId.Value(_snackMachine);
            else if(commandKeyAsShort == CommandReturnMoneyId.Key) CommandReturnMoneyId.Value(_snackMachine);
            else throw new InvalidOperationException("Invalid command");
        }
    }
}
