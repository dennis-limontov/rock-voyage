using System;

namespace JsonHelpers
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class SerializeIfGreaterThanCurrentAttribute : Attribute
    {
    }
}
