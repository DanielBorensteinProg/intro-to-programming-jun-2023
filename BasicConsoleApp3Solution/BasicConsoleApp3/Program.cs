




using GeneralUtilities;

Console.Write("Enter your first name: ");
string firstName = Console.ReadLine();
Console.Write("Enter your last name: ");
string lastName = Console.ReadLine();


string fullName = Formatters.FormatName(firstName, lastName);
Console.WriteLine($"Hello, {fullName}");
