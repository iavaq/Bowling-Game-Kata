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
            List<string> frames = (scores+" ").Split(delimiters).ToList();
            int frame = 0;
            bool strike = false;
            int spare = 0;
            int score = 0;
            List<int> strikeFrames = new List<int>{ };

            for (int i=0; i<(frames.Count)-1; i++)
            {
                frame = 0;
                strike = false;
                foreach (char c in frames[i])
                {
                    switch (c)
                    {
                        case 'X':
                            {
                                strike = true;
                                if (i < 9)
                                    strikeFrames.Add(i + 1);
                                
                                if (spare > 0)
                                {
                                    //strike is worth twice, if spare before
                                    score = 20;
                                    spare = 0;
                                }
                                else
                                    score = 10;
                                break;  
                            }
                        case '/':
                            {
                                if (i <= 9)
                                {
                                    spare = 10 - score;
                                    score = spare;
                                }
                               else
                                   frame = 10;
                                
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
                if (strikeFrames.Any())
                {
                    //if strike, next frame is worth twice
                    if (strikeFrames[0]==i)
                    {
                        frame = 2 * frame;
                        if (strike)
                            frame += 10;

                        strikeFrames.RemoveAt(0);
                    }
                }
                runningTotal += frame;
            }
            return runningTotal;
        }
    }
}
