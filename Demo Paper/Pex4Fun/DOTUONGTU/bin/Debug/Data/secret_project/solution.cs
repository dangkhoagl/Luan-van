using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class Program {
    public static int Puzzle(byte number) {
        int ct = 0;
        while (number != 0) {
            if (number % 2 > 0) ct++;
            number >>= 1;
        }
        return ct;
    }
}

