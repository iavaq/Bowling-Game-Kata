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
                    //score = 0;
                    switch (c)
                    {
                        case 'X':
                            {
                                strike = true;
                                score = 10;
                                if (spare > 0)
                                {
                                    frame = 10;
                                    strike = false;
                                }
                                break;
                            }
                        case '/':
                            {
                                if (i < 9)
                                {
                                    spare = 10 - score;
                                    score = spare;
                                }
                                else
                                {
                                    frame = 10;
                                    if (strike)
                                        score = 10;
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
                                if (spare > 0 & i <= 9)
                                {
                                    frame += score;
                                    spare = 0;
                                }
                                break;
                            }
                    }

                    frame += score;
                }
                if (strike & (i > 0 & i <= 9))
                {
                    frame = 2 * score + frame;
                    strike = false;
                }
                Console.WriteLine(strike);
                Console.WriteLine(frame);
                runningTotal += frame;
            }
            return runningTotal;
        }
    }
}
