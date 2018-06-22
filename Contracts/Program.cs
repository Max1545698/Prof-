using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public sealed class Item
    {
        public sealed class ShoppingCart
        {
            private List<Item> m_cart = new List<Item>();
            private decimal m_totalCost = 0;
            public ShoppingCart()
            {

            }

            public void AddItem(Item item)
            {
                AddItemHelper(m_cart, item, ref m_totalCost);
            }

            private static void AddItemHelper(List<Item> m_cart, Item newItem, ref decimal totalCost)
            {
                // предусловие
                Contract.Requires(newItem != null);
                Contract.Requires(Contract.ForAll(m_cart, s => s != newItem));
                // постусловие
                Contract.Ensures(Contract.Exists(m_cart, s => s == newItem));
                Contract.Ensures(totalCost >= Contract.OldValue(totalCost));
                Contract.EnsuresOnThrow<IOException>(totalCost == Contract.OldValue(totalCost));

                m_cart.Add(newItem);
                totalCost += 1.00M;
            }
            
            [ContractInvariantMethod]
            private void ObjectInvariant()
            {
                //инварианты
                Contract.Invariant(m_totalCost >= 0);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
