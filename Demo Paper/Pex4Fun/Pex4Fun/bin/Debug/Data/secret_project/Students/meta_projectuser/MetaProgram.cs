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
		public static void Check(int x){
			if (Puzzle1(x) != Puzzle2(x)){
				throw new Exception("Submission failed");
			}
		}
  public static int Puzzle1(int x) {
	if(x>0 && x<100){
        return x - 10;
	}
	else {
        	return x; 
	}
  }

    public static int Puzzle2(int x)    {
	if(x>0 && x<100){
        return x - 10;
	}
	else {
        	return x-20; 
	}
    }

	}
}
