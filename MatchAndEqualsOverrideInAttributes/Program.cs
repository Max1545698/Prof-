using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MatchAndEqualsOverrideInAttributes
{
    [Flags]
    internal enum Accounts
    {
        Savings = 0x0001,
        Checking = 0x0002,
        Brokerage = 0x0004
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    internal sealed class AccountsAttribute : Attribute
    {
        private Accounts m_accounts;

        public AccountsAttribute(Accounts accounts)
        {
            m_accounts = accounts;
        }

        public override bool Match(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            AccountsAttribute other = (AccountsAttribute)obj;

            if ((other.m_accounts & m_accounts) != m_accounts)
                return false;

            return true;

        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            if (this.GetType() != obj.GetType()) return false;

            AccountsAttribute other = (AccountsAttribute)obj;

            if ((other.m_accounts & m_accounts) != m_accounts) return false;

            return true;
        }

        public override int GetHashCode()
        {
            return (int)m_accounts;
        }



    }

    [Accounts(Accounts.Savings)]
    internal sealed class ChildAccount
    {

    }

    [Accounts(Accounts.Savings | Accounts.Checking | Accounts.Brokerage)]
    internal sealed class AdultAccount
    {

    }
    public sealed class Program
    {
        public static void Main(string[] args)
        {
            CanWriteCheck(new ChildAccount());
            CanWriteCheck(new AdultAccount());
            CanWriteCheck(new Program());
        }

        private static void CanWriteCheck(object obj)
        {
            Attribute checking = new AccountsAttribute(Accounts.Checking);

            Attribute validAccounts = obj.GetType().GetCustomAttribute<AccountsAttribute>(false);

            if ((validAccounts != null) && checking.Match(validAccounts))
            {
                Console.WriteLine("{0} types can write check.", obj.GetType());
            }
            else
            {
                Console.WriteLine("{0} types can NOT write checks.", obj.GetType());
            }
        }
    }
}
