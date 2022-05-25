using FluentAssertions;
using BowlingKata;

namespace BowlingKataTests
{
    public class BowlerTests
    {
        private Bowler bowler;
        [SetUp]
        public void Setup()
        { 
            bowler = new Bowler();
        }

        [Test]
        public void Should_Return_300_Given_12_Strikes()
        {
            string scores = "X X X X X X X X X X X X ";
            bowler.GetTotalScore(scores).Should().Be(300);
        }
    }
}