using ATM_consoleapp;
using System;

namespace ATM_consoleapp
{
public class Program
    {
        static void Main()
        {
            ATM atm = new ATM();
            Client[] clients = new Client[3];
            clients[0] = new Client("1871", "Sikorski", 1870);
            clients[1] = new Client("1111", "Adasko", 800);
            clients[2] = new Client("1919", "Adminek", 1400);

            int temp = 0;
            int clientNumber = 9999;
            bool loggedIn = false;

            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Enter surname or 'end' to exit: ");
                String surname = Console.ReadLine();
                if (surname == "end")
                {
                    return;
                }
                for (int i = 0; i < 3; i++)
                {
                    if (clients[i].Surname != surname)
                    {
                        continue;
                    }
                    temp = 1;
                    Console.WriteLine("Welcome: " + clients[i].Surname);
                    Console.WriteLine("Enter PIN to log in:");
                    String pin = Console.ReadLine();
                    if (pin == clients[i].Pin)
                    {
                        clientNumber = i;
                        Console.WriteLine("Logged in successfully");
                        Console.Clear();
                        loggedIn = true;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect PIN, please try again!");
                    }
                }
            } while (temp == 0);

            if (!loggedIn)
            {
                return;
            }

            int menu;
            do
            {
                Console.WriteLine("#N-u-m-e-z##B-a-n-k#");
                Console.WriteLine("Choose one of the following options:");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdrawal");
                Console.WriteLine("3. Check balance");
                Console.WriteLine("4. Change PIN");
                Console.WriteLine("5. ATM balance");
                Console.WriteLine("6. Log out");
                menu = int.Parse(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        atm.Deposit(clients[clientNumber]);
                        menu = 0;
                        break;
                    case 2:
                        atm.Withdrawal(clients[clientNumber]);
                        menu = 0;
                        break;
                    case 3:
                        clients[clientNumber].GetBalance();
                        menu = 0;
                        break;
                    case 4:
                        clients[clientNumber].ChangePin();
                        menu = 0;
                        break;
                    case 5:
                        atm.GetATMBalance();
                        atm.BanknotesInATM();
                        menu = 0;
                        break;
                    case 6:
                        {
                            loggedIn = false;
                            break;
                        }
                }
            } while (menu > 5 || menu == 0);

            Console.ReadKey();
        }
    }
}