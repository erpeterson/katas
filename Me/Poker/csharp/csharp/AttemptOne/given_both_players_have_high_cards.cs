using System.Linq;
using NUnit.Framework;

namespace csharp.AttemptOne
{
  [TestFixture]
  public class given_both_players_have_high_cards
  {

    [TestCase(new[] { 2, 5, 7, 8, 9 }, new[] { 2, 5, 6, 7, 8 }, ShowdownOutcome.PlayerOneWins, TestName = "then player one wins because they have the highest card")]
    [TestCase(new[] { 2, 3, 6, 8, 9 }, new[] { 3, 4, 5, 8, 10 }, ShowdownOutcome.PlayerTwoWins, TestName = "then player two wins because they have the highest card")]
    public void when_determining_the_winner_of_a_showdown(int[] PlayerOnesHand, int[] PlayerTwosHand, ShowdownOutcome ExpectedOutcome)
    {
      var Game = new PokerGame();

      Assert.AreEqual(ExpectedOutcome, Game.Showdown(PlayerOnesHand, PlayerTwosHand));      
    }
  }

  public class PokerGame {
    public ShowdownOutcome Showdown(int[] PlayerOnesHand, int[] PlayerTwosHand) {
      return PlayerOnesHand.Max() > PlayerTwosHand.Max() ? ShowdownOutcome.PlayerOneWins : ShowdownOutcome.PlayerTwoWins;
    }
  }

  public enum ShowdownOutcome {
    PlayerOneWins,
    PlayerTwoWins
  }
}