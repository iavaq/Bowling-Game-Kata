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
            string scores = "X X X X X X X X X X X X";
            bowler.GetTotalScore(scores).Should().Be(300);
        }

        [Test]
        public void Should_Return_90()
        {
            string scores = "9- 9- 9- 9- 9- 9- 9- 9- 9- 9-";
            bowler.GetTotalScore(scores).Should().Be(90);
        }

        [Test]
        public void Should_Return_150()
        {
            string scores = "5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/ 5/5";
            bowler.GetTotalScore(scores).Should().Be(150);
        }

        [Test]
        public void Should_Return_70()
        {
            string scores = "61 61 61 61 61 61 61 61 61 61";
            bowler.GetTotalScore(scores).Should().Be(70);
        }
    }
}