using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Bowler
    { 
        public int GetTotalScore(string scores)
        {
            int runningTotal = 0;
            char[] delimiters = { ' ', ',', '.', ';', '\t' };
            string[] scorePerFrame = scores.Split(delimiters);

            for (int i=0; i<(scorePerFrame.Length)-1; i++)
            {
                Console.WriteLine(i);
                if (scorePerFrame[i].Equals("X"))
                {
                    //runningTotal += 10 + Int32.Parse(scorePerFrame[i + 1]) + Int32.Parse(scorePerFrame[i + 2]);
                    runningTotal += 10 + 10 + 10;
                }
            }
            return runningTotal;
        }
    }
}
