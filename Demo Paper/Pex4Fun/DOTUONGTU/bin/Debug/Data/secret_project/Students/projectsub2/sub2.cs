using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Submission {
[PexClass(typeof(Program))]
public class Program {
    [PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]
    public static int Puzzle(byte number)
    {
        var sum = 0;
        for (int i = 0; i < 8; i++)
        {
            sum += (number >> i & 1);
        }
        return sum;        
    }
}
}
