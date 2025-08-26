using T.SQL.Core;

namespace T.SQL.Test;

[Table]
internal partial class DTO
{
    int i;

    int I { get => i; set => i = value; }

    public void DoSomething()
    {
        Console.WriteLine("Doing something");
    }
}