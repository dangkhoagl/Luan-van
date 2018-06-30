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
        return (int)(number / 2);
    }
}
}
