using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM_consoleapp
{
    internal class Client
    {
        public readonly string Surname;
        public string Pin;
        internal int AccountBalance;

        public Client(string pin, string surname, int accountBalance)
        {
            this.Pin = pin;
            this.Surname = surname;
            this.AccountBalance = accountBalance;
        }

        public void ChangePin()
        {
            string newPin = "";
            string oldPin;
            do
            {
                Console.Write("Enter old pin: ");
                oldPin = Console.ReadLine();
                if (oldPin == Pin)
                {
                    Console.WriteLine("Enter new pin: ");
                    newPin = Console.ReadLine();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("You have entered the wrong pin, returning to the menu.");
                }

            } while (newPin != null && (newPin.Length > 4 || newPin.Length <= 0));
            Pin = newPin;
        }
        public void GetBalance()
        {
            Console.WriteLine("You currently have: " + AccountBalance + " in your account.");
        }
    }
}