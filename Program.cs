using System;

class Program
{
    static void Main(string[] args)
    {
        int digits = 0;
        char[] pwd;
        int min = 6;
        int max = 16;
        string alpha = "abcdefghijklmnopqrstuvwxyz";
        string caps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numeric = "0123456789";
        string specials = "!@#$%&*-_=+{}[]";

        do {
            Console.Write("Enter the number of characters to be generated ({0} - {1}): ", min, max);
            if (!int.TryParse(Console.ReadLine(), out digits))
            {
                Console.WriteLine("Please enter a whole number between {0} and {1}", min, max);
            }
        } while ( digits < min || digits > max);

        Random rdm = new Random();
        pwd = new char[digits];
        for (int i = 0;i < digits; i++)
        {
            char a = alpha[rdm.Next(alpha.Length)];
            // check for duplicate
            if (!Array.Exists(pwd, element => element == a) )
                pwd.SetValue(a, i);
            else
            {
                i--;
            }
        }

        Console.Write("Include numericals? [Y/N]: ");
        string input = Console.ReadLine();
        if (input == "Y" || input == "y")
            pwd.SetValue(numeric[rdm.Next(numeric.Length)], rdm.Next(pwd.Length));

        Console.Write("Include capital letters? [Y/N]: ");
        input = Console.ReadLine();
        if (input == "Y" || input == "y")
            pwd.SetValue(caps[rdm.Next(caps.Length)], rdm.Next(pwd.Length));

        Console.Write("Include special characters? [Y/N]: ");
        input = Console.ReadLine();
        if (input == "Y" || input == "y")
            pwd.SetValue(specials[rdm.Next(specials.Length)], rdm.Next(pwd.Length));

        Console.WriteLine();
        Console.WriteLine($"Generated {digits} digits password ::> {new string(pwd)}");
        Console.Write("\nPress any key to exit...");
        Console.ReadKey(true);
    }
}
