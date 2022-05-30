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
            int strike = 0;
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
                                strike = 2;
                                score = 10;
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
                                    if (strike > 0)
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
                
                if (strike>0 & (i > 0 & i <= 9))
                {
                    //Console.WriteLine(strike);
                    frame += strike * score  ;
                    strike = 0;
                }
                Console.WriteLine(frame);
                runningTotal += frame;
            }
            return runningTotal;
        }
    }
}
