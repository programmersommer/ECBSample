using static ECBSample.Boundary;

// in Clean Architecture we have one way dependency direction
// In ECB controller has dependencies in both directions 
// it could have relations with Entities and with boundaries
namespace ECBSample
{
    public class BankController 
    {
        private readonly Account _account;
        private readonly AskDelegate _ask;
        private readonly DisplayDelegate _display;

        public delegate decimal GetPercentageDelegate();

        public BankController(AskDelegate ask, DisplayDelegate display)
        {
            var c = new GetPercentageDelegate(GetPercentage);

            _ask = ask;
            _display = display;
            _account = new Account(c);
        }

        private decimal GetPercentage()
        {
            // some complicated logic could be added here
            return 0.04m;
        }

        public bool CallCommand(string command)
        {
            if (command == "Deposit")
            {
                var amount = int.Parse(_ask.Invoke("How much would you like to deposit?"));
                var depositCheckResult = _account.IsDepositValid(amount);
                if (depositCheckResult.result)
                {
                    _account.Amount = amount;
                }
                else
                {
                    _display.Invoke(depositCheckResult.message);
                }
            }
            else if (command == "GetBalance")
            {
                var years = int.Parse(_ask.Invoke("How many years do you plan to keep deposit?"));
                _display.Invoke($"You account balance in {years} years would be " + _account.GetBalance(years).ToString());
            }

            return true;
        }

    }
}
