using System.ComponentModel;

namespace T.SQL.Core;

/// <summary>
/// Use to decorate a class, struct or interface that represents a database table entry.
/// </summary>
[Description("Used by T.SQL.CodeGenerator")]
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface)]
public class TableAttribute : Attribute
{
}
