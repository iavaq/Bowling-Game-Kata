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

        [Test]
        public void Should_Return_133()
        {
            string scores = "14 45 6/ 5/ X -1 7/ 6/ X 2/ 6";
            bowler.GetTotalScore(scores).Should().Be(133);
        }

        [Test]
        public void Should_Return_187()
        {
            string scores = "X 9/ 5/1 72 X X X 9- 8/ 9/ X";
            bowler.GetTotalScore(scores).Should().Be(187);
        }

        [Test]
        public void Should_Return_12()
        {
            string scores = "5/ 1- -- -- -- -- -- -- -- --";
            bowler.GetTotalScore(scores).Should().Be(12);
        }

        [Test]
        public void Should_Return_14()
        {
            string scores = "X 11 -- -- -- -- -- -- -- --";
            bowler.GetTotalScore(scores).Should().Be(14);
        }
    }
}