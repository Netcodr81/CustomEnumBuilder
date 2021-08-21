
using CustomEnum.BaseClass;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomEnum
{
    public abstract class Enumeration<TValue> : Enumeration, IComparable where TValue : IComparable
    {
        protected Enumeration(TValue value, string displayName)
          : base(value, displayName)
        {

        }

        public virtual TValue Value => (TValue)base.Value;

        public virtual int CompareTo(object other)
        {
            return this.Value.CompareTo((object)((Enumeration<TValue>)other).Value);
        }
    }
}
