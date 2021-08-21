using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnum.Tests
{
    public class GenderEnum : Enumeration<string>
    {
        protected GenderEnum(string value, string displayName) : base(value, displayName)
        {

        }

        public static GenderEnum Male = new GenderEnum("M", "Male");
        public static GenderEnum Female = new GenderEnum("F", "Female");
        public static GenderEnum Unknown = new GenderEnum("U", "Unknown");
    }
}
