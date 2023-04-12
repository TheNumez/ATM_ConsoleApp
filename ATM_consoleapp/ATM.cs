using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_consoleapp
{
    internal class ATM
    {
        int[] banknotes = new int[6];
        readonly int[] denominations = { 500, 200, 100, 50, 20, 10 };

        public ATM()
        {
            var rand = new Random();
            banknotes[0] = rand.Next(101);
            banknotes[1] = rand.Next(101);
            banknotes[2] = rand.Next(101);
            banknotes[2] = rand.Next(101);
            banknotes[3] = rand.Next(101);
            banknotes[4] = rand.Next(101);
            banknotes[5] = rand.Next(101);
        }

        public int GetATMBalance()
        {
            return ((banknotes[0] * 500) + (banknotes[1] * 200) + (banknotes[2] * 100) + (banknotes[3] * 50) + (banknotes[4] * 20) + (banknotes[5] * 10));
        }

        public void Deposit(Client client)
        {
            do
            {
                Console.WriteLine("Select the denominations you are depositing, one by one:");
                Console.WriteLine("1. 500");
                Console.WriteLine("2. 200");
                Console.WriteLine("3. 100");
                Console.WriteLine("4. 50");
                Console.WriteLine("5. 20");
                Console.WriteLine("6. 10");
                Console.WriteLine("7. Exit/Mistake");

                int choice = int.Parse(Console.ReadLine());
                int amount = 0;
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("Enter the amount of 500: ");
                            amount = int.Parse(Console.ReadLine());
                            banknotes[0] += amount;
                            client.AccountBalance += amount * 500;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("Enter the amount of 200: ");
                            amount = int.Parse(Console.ReadLine());
                            banknotes[1] += amount;
                            client.AccountBalance += amount * 200;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter the amount of 100: ");
                            amount = int.Parse(Console.ReadLine());
                            banknotes[2] += amount;
                            client.AccountBalance += amount * 100;
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter the amount of 50: ");
                            amount = int.Parse(Console.ReadLine());
                            banknotes[3] += amount;
                            client.AccountBalance += amount * 50;
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter the amount of 20: ");
                            amount = int.Parse(Console.ReadLine());
                            banknotes[4] += amount;
                            client.AccountBalance += amount * 20;
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine("Enter the amount of 10: ");
                            amount = int.Parse(Console.ReadLine());
                            banknotes[5] += amount;
                            client.AccountBalance += amount * 10;
                            break;
                        }
                    case 7:
                        {
                            return;
                        }
                }
            } while (true);
        }

        public void Withdrawal(Client customer)
        {
            int i = 0;
            Console.Write("How much would you like to withdraw: ");
            int amount = int.Parse(Console.ReadLine());
            if (amount % 10 != 0)
            {
                Console.WriteLine("The ATM does not dispense coins, only amounts in multiples of 10 are accepted!");
            }
            else if (amount > customer.AccountBalance)
            {
                Console.WriteLine("Your balance does not allow for this operation :(");
            }
            else if (amount > GetATMBalance())
            {
                Console.WriteLine("The ATM is not able to dispense that amount, please go to the Bank for cash :(");
            }
            else
            {
                while (amount > 0)
                {
                    int n = amount / denominations[i];
                    if (n > banknotes[i])
                    {

                        customer.AccountBalance -= denominations[i] * banknotes[i];
                        amount = amount - denominations[i] * banknotes[i];
                        Console.WriteLine("Dispensed banknotes: " + denominations[i] + " in quantity:  " + banknotes[i]);
                        banknotes[i] = 0;
                        i++;
                        continue;
                    }
                    banknotes[i] = banknotes[i] - n;
                    customer.AccountBalance -= denominations[i] * n;
                    amount = amount % denominations[i];
                    if (n != 0)
                    {
                        Console.WriteLine("Dispensed banknotes: " + denominations[i] + " in quantity:  " + n);
                    }
                    i++;
                }
                Console.WriteLine("Thank you for using the ATM :)");
            }
        }


        public void BanknotesInATM()
        {
            Console.WriteLine("ATM banknote inventory: ");
            Console.WriteLine("Number of tens = " + banknotes[5]);
            Console.WriteLine("Number of twenties = " + banknotes[4]);
            Console.WriteLine("Number of fifties = " + banknotes[3]);
            Console.WriteLine("Number of hundreds = " + banknotes[2]);
            Console.WriteLine("Number of two hundreds = " + banknotes[1]);
            Console.WriteLine("Number of five hundreds = " + banknotes[0]);
            Console.WriteLine("ATM total balance: " + GetATMBalance());
        }
    }
}
