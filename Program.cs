using System;
class Program
{
    static void Main(string[] args)
    {
        int digits, n, c, s;
        char[] pwd;
        int min = 6;
        int max = 16;
        string alpha = "abcdefghijklmnopqrstuvwxyz";
        string caps = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string numeric = "0123456789";
        string specials = "!@#$%&*-_=+[]";
        Random rdm = new Random((int)DateTime.Now.Ticks);
        digits = n = c = s = 0;

        do {
            Console.Write($"Enter the number of characters to be generated ({min} - {max}): ");
            if (!int.TryParse(Console.ReadLine(), out digits))
            {
                Console.WriteLine($"Please enter a whole number between {min} and {max}");
            }
        } while ( digits < min || digits > max);

        pwd = new char[digits];

        // generate random lowercase letters
        // to the length of user's request
        for (int i = 0;i < digits; i++)
        {
            char a = alpha[GetDigit(rdm,alpha.Length)];
            // check for duplicate
            if (!Array.Exists(pwd, element => element == a) )
                pwd.SetValue(a, i);
            else
                i--;
        }

        // maybe make 2 parts when digits is equal or larger than 12??

        Console.Write("Include numericals? [Y/N]: ");
        string input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            n = GetDigit(rdm, pwd.Length);
            pwd.SetValue(numeric[GetDigit(rdm,numeric.Length)], n);
        }

        Console.Write("Include capital letters? [Y/N]: ");
        input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            do {
                c = GetDigit(rdm, pwd.Length);
            } while (c == n);

            pwd.SetValue(caps[GetDigit(rdm,caps.Length)], c);
        }

        Console.Write("Include special characters? [Y/N]: ");
        input = Console.ReadLine();
        if (input == "Y" || input == "y")
        {
            do {
                s = GetDigit(rdm, pwd.Length);
            } while (s == n || s == c );
            pwd.SetValue(specials[GetDigit(rdm,specials.Length)], s );
        }

        Console.WriteLine();
        Console.WriteLine($"Generated {digits} chars password ::> {new string(pwd)}");
        Console.Write("\nPress any key to exit...");
        Console.ReadKey(true);
    }

    static int GetDigit(Random rnd, int max)
    {
        return rnd.Next(max);
    }
}
