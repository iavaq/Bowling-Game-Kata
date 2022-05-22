using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingKata
{
    public class Bowler
    { 
        public string FrameScores { get; private set; }
        public int TotalScore { get; private set; }

        public Bowler(string frameScores)
        {
            FrameScores = frameScores;
            TotalScore = GetTotalScore();
        }

        public int GetTotalScore()
        {
            int runningTotal = 0;
            char[] delimiters = { ' ', ',', '.', ';', '\t' };
            string[] scores = FrameScores.Split(delimiters);

            for (int i=0; i<=scores.Length; i++)
            {
                if (scores[i].Equals("x"))
                {
                    runningTotal += 10 + Int32.Parse(scores[i + 1]) + Int32.Parse(scores[i + 2]);
                }
            }

            return runningTotal;
        }
    }
}
