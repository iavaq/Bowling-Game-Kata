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
            int frame = 0;
            bool strike = false;
            bool spare = false;
            int score = 0;


            for (int i=0; i<(scorePerFrame.Length)-1; i++)
            {
                Console.WriteLine(frame);
                Console.WriteLine(scorePerFrame[i]);
                frame = 0;
                foreach (char c in scorePerFrame[i])
                { 
                    score = 0;
                    switch (c)
                    {
                        case 'X':
                            {
                                strike = true;
                                score = 10;
                                break;
                            }
                        case '/':
                            {
                                spare = true;
                                score = 10;
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
                                break;
                            }
                    }
                    if (spare)
                    {
                        frame += score;
                        spare = false;
                    }

                    frame += score;
                }
                if (strike)
                {
                    //if strike, count frameScore twice
                    frame += frame ;
                    strike = false;
                }
                runningTotal += frame;
            }
            return runningTotal;
        }
    }
}
