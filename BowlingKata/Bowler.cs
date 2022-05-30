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
            //List<string> result = s?.Split(',').ToList()
            List<string> scorePerFrame = (scores+" ").Split(delimiters).ToList();
            int frame = 0;
            //int strike = 0;
            int spare = 0;
            int score = 0;
            int nextFrame=0;

            for (int i=0; i<(scorePerFrame.Count)-1; i++)
            {
                
                frame = 0;
                foreach (char c in scorePerFrame[i])
                {
                    //score = 0;
                    switch (c)
                    {
                        case 'X':
                            {
                                score = 10;
                                if (nextFrame.Equals(i))
                                    goto StrikeAgain;
                                nextFrame = i + 1;
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
                                    if (nextFrame > i)
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

                StrikeAgain:
                if ((nextFrame.Equals(i)) & (i > 0 & i <= 9))
                {
                    //if strike, next frame is worth twice
                    frame += 2 * frame;
                    nextFrame = i;
                }



                Console.WriteLine(frame);
                runningTotal += frame;
            }
            return runningTotal;
        }
    }
}
