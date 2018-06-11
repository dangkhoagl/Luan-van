using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Settings;
namespace MetaProject{
	[PexClass(typeof(MetaProgram))]
	public class MetaProgram{
		[PexMethod(TestEmissionFilter=PexTestEmissionFilter.All)]
		public static void Check(string x){
			if (Puzzle1(x) != Puzzle2(x)){
				throw new Exception("Submission failed");
			}
		}
  public static string Puzzle1(string x) {
        if (x == "Hello") return "OK";
        if (x == "Demo") return "OK";
        return "NOT OK";
  }

    public static string Puzzle2(string x)
    {
        
        return "NOT OK";
    }

	}
}
