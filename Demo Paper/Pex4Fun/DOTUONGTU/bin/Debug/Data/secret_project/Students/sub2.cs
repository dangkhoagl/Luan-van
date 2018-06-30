using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Program {
    public static int Puzzle(byte number)
    {
        var sum = 0;
        for (int i = 0; i < 8; i++)
        {
            sum += (number >> i & 1);
        }
        return sum;        
    }
}
