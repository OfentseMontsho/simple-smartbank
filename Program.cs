using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartbankUI
{
    internal class Program
    {
        public static List<TransactionHistory> History = new List<TransactionHistory>();
        public string Name { get; set; } = "No Account Found";
        public double Balance { get; set; } = 0;

        public void Header()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "===============================================\n" +
                "                SMARTBANK SYSTEM               \n" +
                "==============================================="
            );
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.WriteLine("         Welcome To The Smartbank System       \n");
            Console.ResetColor();
        }

        public void Menu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "===============================================\n" +
                "1. Create An Account\n" +
                "2. Deposit\n" +
                "3. Withdraw\n" +
                "4. View Account Details\n" +
                "5. View Transaction History\n" +
                "6. Exit\n" +
                "SELECT AN OPTION\n" +
                "===============================================\n"
            );
            Console.ResetColor();
        }

        private int ReadMenuOption()
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (int.TryParse(input, out int option) && option >= 1 && option <= 6)
                    return option;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "=====================================================\n" +
                    "INVALID INPUT! Please enter a menu option (1-6).\n" +
                    "=====================================================\n"
                );
            }
        }

        public void CreateAccount()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "Enter the Account Holder Name: \n" +
                "===============================================\n"
            );
            Name = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "===============================================\n" +
                "Enter the Initial Deposit: \n"
            );

            double initialDeposit = CorrectInt();
            Balance = initialDeposit;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "===============================================\n" +
                "ACCOUNT SUCCESSFULLY CREATED!\n" +
                "===============================================\n" +
                $"- Account Holder: {Name}\n" +
                $"- Initial Deposit: {initialDeposit}\n" +
                "===============================================\n"
            );
            Loading();
        }

        public void Deposit()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "==================================================\n" +
                "Enter the Deposit Amount: \n"
            );

            double depositAmount = CorrectInt();

            Balance += depositAmount;

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "===================================================\n" +
                $"* You have successfully deposited: {depositAmount}\n" +
                $"* Current Balance: {Balance}\n" +
                "===================================================\n"
            );

            History.Add(new TransactionHistory("* Deposit: ", depositAmount));
            Loading();
        }

        public void Withdraw()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "===================================================\n" +
                "Enter Withdrawal amount: \n"
            );

            double withdrawAmount = CorrectInt();

            if (withdrawAmount > Balance)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "===============================================\n" +
                    $"- You have INSUFFICIENT FUNDS\n" +
                    $"- Your current Balance is:  {Balance} \n" +
                    "=============================================\n"
                );
            }
            else
            {
                Balance -= withdrawAmount;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "===============================================\n" +
                    $"* You have successfully withdrawn: {withdrawAmount}\n" +
                    $"* Your Current Balance is: {Balance}\n" +
                    "================================================\n"
                );

                History.Add(new TransactionHistory("- Withdrawal: ", withdrawAmount));
            }

            Loading();
        }

        public void ViewAccountDetails()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "======================================================\n" +
                $"- Account Holder Name: {Name} \n" +
                $"- Current Balance: {Balance} \n" +
                "======================================================\n"
            );
            Loading();
        }

        public double CorrectInt()
        {
            double result;
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out result) && result >= 0)
                    return result;

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "=====================================================\n" +
                    "INVALID INPUT! ENTER A VALID DIGIT\n" +
                    "=====================================================\n"
                );
            }
        }

        public void Loading()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("****             Tap on any key to continue ...          ****\n");
            Console.ReadKey();
        }

        public void ViewTransactionHistory()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(
                "========================================================\n" +
                "TRANSACTION HISTORY: \n"
            );

            if (History.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(
                    "No transaction found.\n" +
                    "=========================================================\n"
                );
                Loading();
            }
            else
            {
                foreach (var transaction in History)
                    transaction.DisplayTransaction();

                Loading();
            }
        }

        static void Main(string[] args)
        {
            Program ob = new Program();
            ob.Header();
            ob.Menu();

            int option = ob.ReadMenuOption();

            bool term = true;

            while (term)
            {
                switch (option)
                {
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You have chosen: CREATE ACCOUNT\n");
                        Console.ReadKey();
                        ob.CreateAccount();
                        ob.Menu();
                        option = ob.ReadMenuOption();
                        break;

                    case 2:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You have chosen: DEPOSIT\n");
                        Console.ReadKey();
                        ob.Deposit();
                        ob.Menu();
                        option = ob.ReadMenuOption();
                        break;

                    case 3:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You have chosen: WITHDRAW\n");
                        Console.ReadKey();
                        ob.Withdraw();
                        ob.Menu();
                        option = ob.ReadMenuOption();
                        break;

                    case 4:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You have chosen: VIEW ACCOUNT DETAILS\n");
                        Console.ReadKey();
                        ob.ViewAccountDetails();
                        ob.Menu();
                        option = ob.ReadMenuOption();
                        break;

                    case 5:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You have chosen: VIEW TRANSACTION HISTORY\n");
                        Console.ReadKey();
                        ob.ViewTransactionHistory();
                        ob.Menu();
                        option = ob.ReadMenuOption();
                        break;

                    case 6:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You have chosen: EXIT. GOODBYE.");
                        term = false;
                        break;

                    default:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Invalid Input\n");
                        term = false;
                        break;
                }
            }
        }
    }
}