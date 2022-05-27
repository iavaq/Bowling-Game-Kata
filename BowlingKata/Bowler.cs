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
            string[] scorePerFrame = (scores+" ").Split(delimiters);
            int frame = 0;
            bool strike = false;
            int spare = 0;
            int score = 0;


            for (int i=0; i<(scorePerFrame.Length)-1; i++)
            {
                frame = 0;
                foreach (char c in scorePerFrame[i])
                {
                    
                    switch (c)
                    {
                        case 'X':
                            {
                                strike = true;
                                frame = 10;
                                break;
                            }
                        case '/':
                            {
                                if (i < 9)
                                {
                                    spare = 10 - score;
                                    score = spare;
                                }
                                break;
                            }
                        case '-':
                            {
                                score = 0;
                                break;
                            }
                        default:
                            {
                                score = (int)Char.GetNumericValue(c);
                                if (spare>0 & i<10)
                                {
                                    frame += spare;
                                    spare = 0; 
                                }
                                break;
                            }
                    }
                    frame += score;
                    if (strike & (i>0 & i<10))
                    {
                        //if strike, count frame twice
                        frame += 2 * frame;
                        strike = false;
                    }
                }
                runningTotal += frame;
            }
            return runningTotal;
        }
    }
}
