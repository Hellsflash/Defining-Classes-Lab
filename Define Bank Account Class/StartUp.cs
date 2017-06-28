using System;
using System.Collections.Generic;

namespace Define_Bank_Account_Class
{
    public class StartUp
    {
        static void Main()
        {

            var accounts = new Dictionary<int, BankAccount>();

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var args = command.Split();



                switch (args[0])
                {
                    case "Create":
                        Create(int.Parse(args[1]), accounts);
                        break;
                    case "Deposit":
                        Deposit(int.Parse(args[1]), double.Parse(args[2]), accounts);
                        break;
                    case "Withdraw":
                        Withdraw(int.Parse(args[1]), double.Parse(args[2]), accounts);
                        break;
                    case "Print":
                        Print(int.Parse(args[1]), accounts);
                        break;
                }
            }

        }

        private static void Print(int id, Dictionary<int, BankAccount> accounts)
        {
            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
            }
            else
            {
                Console.WriteLine(accounts[id].ToString());
            }

        }

        private static void Withdraw(int id, double amount, Dictionary<int, BankAccount> accounts)
        {

            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return;
            }
            else
            {

                if (accounts[id].Balance < amount)
                {
                    Console.WriteLine("Insufficient balance");
                    return;
                }
                else
                {
                    accounts[id].Withdraw(amount);
                }
            }
        }

        private static void Deposit(int id, double amount, Dictionary<int, BankAccount> accounts)
        {


            if (!accounts.ContainsKey(id))
            {
                Console.WriteLine("Account does not exist");
                return;
                
            }
            else
            {
                
                accounts[id].Deposit(amount);
            }
        }

        private static void Create(int id, Dictionary<int, BankAccount> accounts)
        {

            if (accounts.ContainsKey(id))
            {
                Console.WriteLine("Account already exists");
                return;
            }
            else
            {
                accounts[id] = new BankAccount(id);
            }
        }
    }

}