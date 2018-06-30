using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Program {
  public static int Puzzle(int x) {
	if(x>0 && x<100){
        return x - 10;
	}
	else {
        	return x; 
	}
  }
}