using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class BitArray64 : IEnumerable<int>
    {
        private ulong value;

        public BitArray64(ulong value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            BitArray64 number = (obj as BitArray64);
            if ((object)number == null) return false;
            return this.value.Equals(number.value);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(BitArray64 first,  object second)
        {
            if (first.value.Equals(second))
                return true;
            else
                return false;
        }

        public static bool operator !=(BitArray64 first, object second)
        {
            if (!first.value.Equals(second))
                return true;
            else
                return false;
        }

        public int this[int key]
        {
            get
            {
                //make shure the key is correct
                if (key < 0 || key > 63)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (((ulong)(1 << key) & this.value) > 0)
                    return 1;
                else
                    return 0;
            }
            set 
            {
                //make shure the key is correct
                if (key < 0 || key > 63)
                {
                    throw new ArgumentOutOfRangeException();
                }

                if (value == 1)
                {
                    this.value = this.value | (ulong)(1 << key);
                }
                else
                {
                    this.value = this.value & (ulong)((~1) << key);
                }
            }

        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }


        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
