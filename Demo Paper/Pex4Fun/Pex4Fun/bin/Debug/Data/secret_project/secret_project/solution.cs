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
  public static string Puzzle(string x) {
        if (x == "Hello") return "OK";
        if (x == "Demo") return "OK";
        return "NOT OK";
  }
}
}
