using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomEnum.BaseClass
{
    public abstract class Enumeration
    {
        protected Enumeration(object value, string displayName)
        {
            this.DisplayName = displayName;
            this.Value = value;
        }

        public virtual object Value { get; protected set; }

        public string DisplayName { get; private set; }

        public override string ToString()
        {
            return this.DisplayName;
        }

        public static IEnumerable<T> GetAll<T>() where T : Enumeration
        {
            return Enumeration.GetFields<T>().Select<FieldInfo, object>((Func<FieldInfo, object>)(info => info.GetValue((object)null))).OfType<T>();
        }

        private static IEnumerable<FieldInfo> GetFields<T>()
        {
            return Enumeration.GetFields(typeof(T));
        }

        private static IEnumerable<FieldInfo> GetFields(Type type)
        {
            return (IEnumerable<FieldInfo>)type.GetFields(BindingFlags.DeclaredOnly | BindingFlags.Static | BindingFlags.Public);
        }

        public static IEnumerable<Enumeration> GetAll(Type type)
        {
            return Enumeration.GetFields(type).Select<FieldInfo, object>((Func<FieldInfo, object>)(info => info.GetValue((object)null))).OfType<Enumeration>();
        }

        public static T FromDisplayName<T>(string displayName) where T : Enumeration
        {
            return Enumeration.Parse<T>((object)displayName, "display name", (Func<T, bool>)(item => item.DisplayName == displayName));
        }

        public static TEnum FromDisplayNameOrNull<TEnum>(string displayName) where TEnum : Enumeration
        {
            return Enumeration.GetAll<TEnum>().SingleOrDefault<TEnum>((Func<TEnum, bool>)(e => e.DisplayName == displayName));
        }

        public static T FromValue<T>(object value) where T : Enumeration
        {
            return Enumeration.Parse<T>(value, nameof(value), (Func<T, bool>)(item => item.Value.Equals(value)));
        }

        public static T FromValueOrNull<T>(object value) where T : Enumeration
        {
            return Enumeration.GetAll<T>().SingleOrDefault<T>((Func<T, bool>)(e => e.Value.Equals(value) || e.Value.ToString().Equals(value)));
        }

        public static Enumeration FromValueOrNull(
          Type enumerationType,
          object enumerationValue)
        {
            return Enumeration.GetAll(enumerationType).SingleOrDefault<Enumeration>((Func<Enumeration, bool>)(e => e.Equals(enumerationValue)));
        }

        public override bool Equals(object obj)
        {
            if (obj is Enumeration enumeration)
                return this.GetType().Equals(obj.GetType()) & this.Value.Equals(enumeration.Value);
            return (obj != null) && (obj.ToString() == this.Value.ToString());
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        private static T Parse<T>(object value, string description, Func<T, bool> predicate) where T : Enumeration
        {
            return Enumeration.GetAll<T>().FirstOrDefault<T>(predicate) ?? throw new ApplicationException($"'{value}' is not a valid {(object)description} in {(object)typeof(T)}");
        }
    }
}
