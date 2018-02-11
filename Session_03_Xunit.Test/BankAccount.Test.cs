using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Session_03_Xunit.Test
{
    public class BankAccountTest
    {
        [Fact]
        public void Debit_WhenIsFrozen_ExpectExcption()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad",1000);
            bankAccount.FreezeAccount();

            //Act
            //Assert
            Assert.Throws<Exception>(()=>bankAccount.Debit(100));
        }

        [Fact]
        public void Debit_WhenAmountIsBigerThanBalance_ExpectArgumentOutOfRangeException()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad", 1000);
            bankAccount.UnfreezeAccount();

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Debit(10001));
        }

        [Fact]
        public void Debit_WhenAmountIsNegative_ExpectArgumentOutOfRangeException()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad", 1000);
            bankAccount.UnfreezeAccount();

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Debit(-10));
        }

        [Fact]
        public void Debit_WhenAmountIsValid_ExpectTrueForBalance()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad", 1000);
            bankAccount.UnfreezeAccount();
            double oldBalance = bankAccount.Balance;
            double amount = 500;
            //Act
            bankAccount.Debit(amount);
            bool result = bankAccount.Balance < oldBalance ? true : false;
            //Assert
            Assert.True(result);
        }

        [Fact]
        public void Credit_WhenIsFrozen_ExpectExcption()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad", 1000);
            bankAccount.FreezeAccount();

            //Act
            //Assert
            Assert.Throws<Exception>(() => bankAccount.Credit(100));
        }


        [Fact]
        public void Credit_WhenAmountIsNegative_ExpectArgumentOutOfRangeException()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad", 1000);
            bankAccount.UnfreezeAccount();

            //Act
            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => bankAccount.Credit(-10));
        }

        [Fact]
        public void Credit_WhenAmountIsValid_ExpectTrueForValidBalance()
        {
            //Arenge
            BankAccount bankAccount = new BankAccount("Mohammad", 1000);
            bankAccount.UnfreezeAccount();
            double oldBalance = bankAccount.Balance;
            double amount = 500;
            
            //Act
            bankAccount.Credit(amount);
            bool result = bankAccount.Balance > oldBalance ? true: false;
            //Assert
            Assert.True(result);
        }

        
    }
    

}
