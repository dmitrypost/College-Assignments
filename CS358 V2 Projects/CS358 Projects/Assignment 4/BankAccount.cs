using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignments.Assignment_4
{
    public class BankAccount
    {
        private double balance = 0.00;  //  



        public double Balance
        {
            get
            {
                return balance;
            }

            
        }


        public double withdraw(double amount)
        {
            if (amount > Balance)
            {
                throw new NegativeBalanceException("there is a negative balance");
                //return Balance;
            }
            else if (amount.ToString().Contains("-") || amount < 0)
            {
                throw new NegativeWithdrawalException("cannot withdraw a negative amount");
                //return Balance;
            }
            //done with checks now actually do the subtracting...
            balance = balance - amount;
            return Balance;


        }

        public double deposit(double amount)
        {
            if (amount.ToString().Contains("-") || amount < 0)
            {
                throw new NegativeDepositException("cannot deposit a negative amount");
            }
            //done with checks; add the balance
            balance = balance + amount;
            return Balance;
        }


    }

    public class NegativeWithdrawalException : Exception
    {
        public NegativeWithdrawalException()
        { }
        public NegativeWithdrawalException(string message)
            : base(message)
        {

        }
        public NegativeWithdrawalException(string message, Exception inner)
            : base(message, inner)
        {

        }
    }

    public class NegativeDepositException : Exception
    {
        public NegativeDepositException()
        {
        }

        public NegativeDepositException(string message)
            : base(message)
        {
        }

        public NegativeDepositException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException()
        {
        }

        public NegativeBalanceException(string message)
            : base(message)
        {
        }

        public NegativeBalanceException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
