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
		public static void Check(byte number){
			if (Puzzle1(number) != Puzzle2(number)){
				throw new Exception("Submission failed");
			}
		}
    public static int Puzzle1(byte number) {
        int ct = 0;
        while (number != 0) {
            if (number % 2 > 0) ct++;
            number >>= 1;
        }
        return ct;
    }

    public static int Puzzle2(byte number) 
    {
        return (int)(number / 2);
    }

	}
}
