using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prof
{
    class Collection : IList
    {
        Citizen[] citizen = new Citizen[0];
        public object this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool IsReadOnly => throw new NotImplementedException();

        public bool IsFixedSize => throw new NotImplementedException();

        public int Count => citizen.Length;

        public object SyncRoot => throw new NotImplementedException();

        public bool IsSynchronized => throw new NotImplementedException();

        public int Add(Citizen citizen)
        {
            if (citizen is Pensioner)
            {
                for (int i = 0; i < this.citizen.Length; i++)
                {
                    if (!(this.citizen[i] is Pensioner))
                    {
                        this.citizen = RemoveIndex(this.citizen, i);
                        this.citizen[i] = citizen;
                        return i;

                    }
                }
            }
            else
            {
                this.citizen = BecomeBiggerArr(this.citizen);

                for (int i = 0; i < this.citizen.Length; i++)
                {
                    if (this.citizen[i] == null)
                    {
                        this.citizen[i] = citizen;
                        return i;
                    }
                }
            }
            return -1;
        }

        private Citizen[] RemoveIndex(Citizen[] citiz, int index)
        {
            
            Citizen[] c = BecomeBiggerArr(citiz, 1);

            c[c.Length - 1] = citiz[citiz.Length - 1];

            for (int i = c.Length - 2; i >= index; i--)
            {
                c[i + 1] = citizen[i];
            }
            c[index] = null;

            return c;
        }

        private Citizen[] BecomeBiggerArr(Citizen[] citiz, int length = 1)
        {
            Citizen[] citizen = new Citizen[citiz.Length + length];
            for (int i = 0; i < citiz.Length; i++)
            {
                citizen[i] = citiz[i];
            }
            return citizen;
        }

        public void Clear()
        {
            citizen = new Citizen[5];
        }

        public bool Contains(object value)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(Array array, int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerator GetEnumerator()
        {
            return citizen.GetEnumerator();
        }

        public int IndexOf(object value)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, object value)
        {
            throw new NotImplementedException();
        }

        public void Remove(object value)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        public int Add(object value)
        {
            throw new NotImplementedException();
        }
    }
}
