using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Program {
  public static int Puzzle(int x) {
	if(x>0 && x<100){
        	if (x == 1) return 100-x;
        	if (x == 22) return 100-x;
		if (x == 33) return 100-x;
        	if (x == 44) return 100-x;
		if (x == 55) return 100-x;
        	
	}
	else {
        	return 101; 
	}
  }
}