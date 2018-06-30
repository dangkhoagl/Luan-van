using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Solution {
[PexClass(typeof(Program))]
public class Program {
    [PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]
    public static int Puzzle(byte number) {
        int ct = 0;
        while (number != 0) {
            if (number % 2 > 0) ct++;
            number >>= 1;
        }
        return ct;
    }
}

}
