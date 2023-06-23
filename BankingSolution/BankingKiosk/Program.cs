using Banking.Domain;



Console.WriteLine("Welcome to the Bank!");
var account = new Account(new StandardBonusCalculator());



Console.WriteLine($"Your Current Balance is {account.GetBalance():c}");



Console.Write("Enter a W to make a withdrawal, Enter a D for a deposit, or Q to Quit: ");



var entry = Console.ReadLine();



if (entry is null)
{
    Console.WriteLine("You stink!");
}
else
{




    if (entry.ToLower().Trim() == "w")
    {
        Console.Write("Amount of Withdrawal: ");
        var amount = decimal.Parse(Console.ReadLine());
        account.Withdraw(amount);

    }
    if (entry.ToLower().Trim() == "d")
    {



        Console.Write("Amount of Deposit: ");
        var amount = decimal.Parse(Console.ReadLine());
        account.Deposit(amount);
    }
    Console.WriteLine($"Good job. Your New Balance is {account.GetBalance():c}");



}