
namespace CSharpStuff;
public class BankAccount
{

    public BankAccount(string email)
    {
        Email = email;
    }
    private decimal _balance = 5000M;

    public string Email { get; private set; } = string.Empty;
   

    public string PhoneNumber { get; set; } = "";
    public decimal GetBalance()
    {
        return _balance;   
    }

    public decimal Balance
    {
        get { return _balance; }
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
    }

    
}


