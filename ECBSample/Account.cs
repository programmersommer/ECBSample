using ECBSample.Interfaces;
using static ECBSample.BankController;

namespace ECBSample
{
    // Entity could have relations with Controller or else Entities
    // in any kind of dependency direction
    public class Account : IAccount
    {
        private readonly GetPercentageDelegate _getPercentage;
        public Account(GetPercentageDelegate getPercentage)
        {
            _getPercentage = getPercentage;
        }

        public decimal Amount { get; set; }

        public decimal GetBalance(int years)
        {
            // percentage doesn't related to account context
            var rate = _getPercentage.Invoke();

            for (var i = 1; i <= years; i++)
            {
                Amount = Amount + Amount * rate;
            }

            return Amount;
        }

        public (bool result, string message) IsDepositValid(decimal amount)
        {
            if (amount < 100) return (false, "You could not deposite less then 100");
            return (true, "");
        }

    }
}
