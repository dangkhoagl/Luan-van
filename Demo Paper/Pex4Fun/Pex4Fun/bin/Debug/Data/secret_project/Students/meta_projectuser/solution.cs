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
  public static int Puzzle(int x) {
	if(x>0 && x<100){
        return x - 10;
	}
	else {
        	return x; 
	}
  }
}
}
