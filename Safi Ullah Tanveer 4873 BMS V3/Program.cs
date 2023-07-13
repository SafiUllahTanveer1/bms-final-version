namespace Safi_Ullah_Tanveer_4873_BMS_V3
{
    using System;
using System.Collections.Generic;

    namespace Safi_Ullah_tanveer_4873_Assignment_2_V2
{
    class GlobalVariables
    {
        public static int MyGlobalVariable = 1;
    }

    public interface ITransaction
    {
        void Execute_Transaction(double amount, int transaction_type);
        void Print_Transaction(int transaction_type, double transaction_amount);
    }

    public class Transaction
    {
        private int transaction_id;
        public int transaction_id_gs { get; set; }
        private int transaction_type;
        public int transaction_type_gs { get; set; }
        private double transaction_amount;
        public double transaction_amount_gs { get; set; }
        private int transaction_account;
        public int transaction_account_gs { get; set; }

        public void print_transaction()
        {
            Console.WriteLine("Transaction done by account is : " + transaction_account + "Transaction id is : " + transaction_id + ". Transaction type is : " + transaction_type
             + ". Transaction amount is : " + transaction_amount);
        }
        
    }
    
    public interface IBankAccount
    {

        void deposit(double deposited);
        void withdraw(double withdrawl_amount);



    }

    public abstract class BankAccount : IBankAccount
    {
        private string Account_Holder_name;
        public string AccountHolder_name { get; set; }

        private int accountNumber;
        public int Account_number { get; set; }

        private double Balance;
        public double balance { get; set; }


        public BankAccount()
        {

        }

        public BankAccount(string person_name, int acc_num, double bal)
        {
            Account_Holder_name = person_name;
            Account_number = acc_num;
            Balance = bal;
        }

        public abstract void deposit(double deposited);


        public abstract void withdraw(double withdrawl_amount);


        public abstract void DisplayAccountInfo();
        
        public abstract void Execute_Transaction(double amount, int transaction_type);
        
        public abstract void Print_Transaction(int transaction_type, double transaction_amount);
        
        



    }

    public class SavingsAccount : BankAccount, IBankAccount, ITransaction
    {
        public double my_Interest_Rate;
        public int my_time = 0;

        public SavingsAccount(string person_name, int acc_num, double bal, double Interest_Rate, int time) : base(
            person_name, acc_num, bal)
        {
            my_Interest_Rate = Interest_Rate;
            my_time = time;

        }

        public override void deposit(double deposited)
        {
            // base.Deposit(deposit);
            Console.WriteLine("\tSAVING ACCOUNTS DEPOSIT FUNCTION.");
            Console.WriteLine("Amount for deposit is : " + deposited);
            Console.WriteLine("Balance before from account holder " + AccountHolder_name + " deposit is : " + balance);
            balance += deposited * my_Interest_Rate * my_time;
            Console.WriteLine("Balance after from account holder " + AccountHolder_name + " deposit is : " + balance);
        }

        public override void withdraw(double withdrawl_amount)
        {
            Console.WriteLine("\tSAVING ACCOUNTS WITHDRAW FUNCTION.");
            double balance = 1000;
            if (withdrawl_amount < balance)
            {
                balance -= withdrawl_amount;
                Console.WriteLine("aBalance in account after withdrawl is:" + balance);
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine(AccountHolder_name);
            Console.WriteLine(Account_number);
            Console.WriteLine(balance);
        }

        public override void Execute_Transaction(double amount, int transaction_type)
        {
            // Console.WriteLine("Enter the transaction type \nEnter 1 for deposit and 0 for withdrawl : ");
            // int transaction_type = int.Parse(Console.ReadLine());
            if (transaction_type == 1)
            {
                deposit(amount);
                Print_Transaction(transaction_type, amount);
            }
            else if (transaction_type == 0)
            {
                withdraw(amount);
                Print_Transaction(transaction_type, amount);
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }
            
            // throw new NotImplementedException();
        }

        public override void Print_Transaction(int transaction_type, double transaction_amount)
        {
            string my_transaction_type = "";
            if (transaction_type == 1)
            {
                my_transaction_type = "Deposit";
            }
            else
            {
                my_transaction_type = "Withdrawl";
            }
            Console.WriteLine("Transaction was done from Account number : " + Account_number + ". Transaction type " +
                              "is " + my_transaction_type + ". Transaction amount is : " + transaction_amount + "" +
                              ". Now updated balance is " + balance);
            // throw new NotImplementedException();
        }
    }

    public class Checking_Account : BankAccount, IBankAccount, ITransaction
    {

        public Checking_Account(string person_name, int acc_num, double bal) : base(person_name, acc_num, bal)
        {

        }

        public override void deposit(double deposited)
        {
            Console.WriteLine("\tCHECKING ACCOUNTS DEPOSIT FUNCTION.");
            Console.WriteLine("Amount for deposit is : " + deposited);
            Console.WriteLine("Balance before from account holder " + AccountHolder_name + " deposit is : " + balance);
            balance += deposited;
            Console.WriteLine("Balance after from account holder " + AccountHolder_name + "deposit is " + balance);
        }

        public override void withdraw(double withdrawl_amount)
        {
            Console.WriteLine("\tCHECKING ACCOUNTS WITHDRAW FUNCTION.");
            if (withdrawl_amount <= balance)
            {
                Console.WriteLine("Amount to withdrawn is : " + withdrawl_amount);
                Console.WriteLine("Balance before from account holder " + AccountHolder_name + " withdraw is : " +
                                  balance);
                balance -= withdrawl_amount;
                Console.WriteLine("Balance after from account holder " + AccountHolder_name + " withdraw is : " +
                                  balance);
                DisplayAccountInfo();
            }
            else
            {
                Console.WriteLine("You don't have sufficient amount");
                DisplayAccountInfo();
            }
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine(AccountHolder_name);
            Console.WriteLine(Account_number);
            Console.WriteLine(balance);
        }

        public override void Execute_Transaction(double amount, int transaction_type)
        {
            // Console.WriteLine("Enter the transaction type \nEnter 1 for deposit and 0 for withdrawl : ");
            // int transaction_type = int.Parse(Console.ReadLine());
            if (transaction_type == 1)
            {
                deposit(amount);
                Print_Transaction(transaction_type, amount);
            }
            else if (transaction_type == 0)
            {
                withdraw(amount);
                Print_Transaction(transaction_type, amount);
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }
            // throw new NotImplementedException();
        }

        public override void Print_Transaction(int transaction_type, double transaction_amount)
        {
            string my_transaction_type = "";
            if (transaction_type == 1)
            {
                my_transaction_type = "Deposit";
            }
            else
            {
                my_transaction_type = "Withdrawl";
            }
            Console.WriteLine("Transaction was done from Account number : " + Account_number + ". Transaction type " +
                              "is " + my_transaction_type + ". Transaction amount is : " + transaction_amount + "" +
                              ". Now updated balance is " + balance);
            // throw new NotImplementedException();
        }
    }

    public class Loan_Account : BankAccount, IBankAccount, ITransaction
    {
        public double interestrate;
        public double paymenttime;
        

        public Loan_Account(string person_name, int acc_num, double bal, double interrate, double my_time) : base(
             person_name, acc_num,  bal)
        {
            interestrate = interrate;
            paymenttime = my_time;
        }

        public override void deposit(double deposited)
        {
            
            // throw new NotImplementedException();
        }

        public void  deposit(double deposited, double interestrate, double paymenttime)
        {
            int i;
            for (i = 0; i < paymenttime; i++)
            {
                double payments = i * (balance / paymenttime);
                deposited += payments;
            }
            // Console.WriteLine("Account holder:"+ AccountHolder_name+"has to pay back "+deposited+ "with interest rate"+interestrate+"in "+ paymenttime+ "years");

        }

        public override void withdraw(double withdrawl_amount)
        {
            Console.WriteLine("Tell bank the loan amount");
            int loanamount = int.Parse(Console.ReadLine());
            withdrawl_amount = loanamount;
            balance = withdrawl_amount;
            Console.WriteLine("The amount of:"+ balance+ "has been withdrawn");

        }

        public override void Execute_Transaction(double amount, int transaction_type)
        {
            // Console.WriteLine("Enter the transaction type \nEnter 1 for deposit and 0 for withdrawl : ");
            // int transaction_type = int.Parse(Console.ReadLine());
            if (transaction_type == 1)
            {
                deposit(amount);
                Print_Transaction(transaction_type, amount);
            }
            else if (transaction_type == 0)
            {
                withdraw(amount);
                Print_Transaction(transaction_type, amount);
            }
            else
            {
                Console.WriteLine("Invalid Input.");
            }

        }

        public override void Print_Transaction(int transaction_type, double transaction_amount)
        {
            string my_transaction_type = "";
            if (transaction_type == 1)
            {
                my_transaction_type = "Deposit";
            }
            else
            {
                my_transaction_type = "Withdrawl";
            }

            Console.WriteLine("Transaction was done from Account number : " + Account_number + ". Transaction type " +
                              "is " + my_transaction_type + ". Transaction amount is : " + transaction_amount + "" +
                              ". Now updated balance is " + balance);
        }

        public override void DisplayAccountInfo()
        {
            Console.WriteLine(AccountHolder_name);
            Console.WriteLine(Account_number);
            Console.WriteLine(balance);
        }
    }



    public class Bank
    {
        public List<BankAccount> BankAccounts { get; set; }
        public List<Transaction> transactions { get; set; }

        public Bank()
        {
            BankAccounts = new List<BankAccount>();
        }

        public void Add_Account()
        {
            Console.WriteLine("Enter the account holder name : ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter the account number : ");
            int acc_num = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the initial balance : ");
            double balance = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter the account type. \n Enter 1 for saving account and 0 for checking account and 2 for loan account:");
            int type = int.Parse(Console.ReadLine());
            if (type == 1)
            {
                Console.WriteLine("Enter the interest rate : ");
                double interest = double.Parse(Console.ReadLine());
                Console.WriteLine("Give the time of interest deposits:");
                int time = int.Parse(Console.ReadLine());
                BankAccount accounts = new SavingsAccount(name, acc_num, balance, interest, time);
                BankAccounts.Add(accounts);
            }

            if (type == 0)
            {
                BankAccount accounts = new Checking_Account(name, acc_num, balance );
                BankAccounts.Add(accounts);
            }

            if (type == 2)
            {
                Console.WriteLine("Give the time you in which you want to pay back");
                double my_time = int.Parse(Console.ReadLine());
                double interrate = 0.1;

                BankAccount accounts = new Loan_Account(name, acc_num, balance, interrate, my_time);
                BankAccounts.Add(accounts);
            }

        }







        public void deposit(double deposited)
        {
            Transaction t = new Transaction();
            
            Console.WriteLine("Give the Account Number for deposits:");
            int acc = int.Parse(Console.ReadLine());
            int i;
            for (i = 0; i < BankAccounts.Count; i++)
            {
                if (acc == BankAccounts[i].Account_number)
                {
                    // Console.WriteLine("Enter the amount for deposit : ");
                    // double amount = double.Parse(Console.ReadLine());
                    BankAccounts[i].Execute_Transaction(deposited, 1);
                    t.transaction_id_gs = GlobalVariables.MyGlobalVariable;
                    GlobalVariables.MyGlobalVariable++;
                    t.transaction_account_gs = acc;
                    t.transaction_type_gs = 1;
                    t.transaction_amount_gs = deposited; 
                    transactions.Add(t);


                }

            }
        }

        public void withdraw(double withdrawl_amount)
        {
            Transaction t = new Transaction();
            Console.WriteLine("Give the Account Number for withdrawl:");
            int acc = int.Parse(Console.ReadLine());
            int i;
            for (i = 0; i < BankAccounts.Count; i++)
            {
                if (acc == BankAccounts[i].Account_number)
                {
                    // Console.WriteLine("Enter the amount for deposit : ");
                    // double amount = double.Parse(Console.ReadLine());
                    BankAccounts[i].Execute_Transaction(withdrawl_amount, 0);
                    t.transaction_id_gs = GlobalVariables.MyGlobalVariable;
                    GlobalVariables.MyGlobalVariable++;
                    t.transaction_amount_gs = withdrawl_amount;
                    t.transaction_account_gs = acc;
                    t.transaction_type_gs = 0;
                    transactions.Add(t);
                }

            }
        }

        public void print_transaction_history()
        {
            for (int i = 0; i < transactions.Count; i++)
            {
                transactions[i].print_transaction();
            }
        }
    }


    internal class Program
    {
        public static void Main(string[] args)
        {
            Bank bank2 = new Bank();
            bank2.Add_Account();
            // bank2.Add_Account();
            // bank2.Add_Account();
            //bank2.Add_Account();
            // Console.WriteLine("Enter value to deposit : ");
            bank2.deposit(1000);
            bank2.withdraw(500);
            // bank2.deposit(1000);
            // bank2.withdraw(500);
            // bank2.deposit(1000);
            // bank2.withdraw(500);

            // Console.WriteLine("Enter value to withdraw : ");
            int amount = 100;
            //bank2.withdraw(amount);
            Console.WriteLine("\tTransaction History is as follow : ");
            bank2.print_transaction_history();
        }
    }
}

}