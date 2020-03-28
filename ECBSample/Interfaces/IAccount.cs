
namespace ECBSample.Interfaces
{
    interface IAccount
    {
        decimal Amount { get; set; }
        decimal GetBalance(int years);
    }
}
