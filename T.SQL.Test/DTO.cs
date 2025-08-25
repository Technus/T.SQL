using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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