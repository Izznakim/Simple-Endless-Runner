using NUnit.Framework;

public class GameSessionTests
{
   private GameSession session;

   [SetUp]
   public void SetUp()
   {
      session = new GameSession();
   }

   // A Test behaves as an ordinary method
   [Test]
   public void ScoreShouldStartAtZero()
   {
      Assert.AreEqual(0, session.Score);
   }

   [Test]
   public void IsGameOverShouldStartAsFalse()
   {
      Assert.IsFalse(session.IsGameOver);
   }

   [Test]
   public void AddScoreShouldIncreaseScoreWhenNotGameOver()
   {
      session.AddScore(1.5f);
      Assert.AreEqual(1.5f, session.Score);
   }

   [Test]
   public void AddScoreShouldNotIncreaseScoreIfGameOver()
   {
      session.EndGame();
      session.AddScore(2f);
      Assert.AreEqual(0f, session.Score);
   }

   [Test]
   public void EndGameShouldSetIsGameOver()
   {
      session.EndGame();
      Assert.IsTrue(session.IsGameOver);
   }

   [Test]
   public void ResetShouldResetScoreAndGameOver()
   {
      session.AddScore(3f);
      session.EndGame();
      session.Reset();

      Assert.AreEqual(0f, session.Score);
      Assert.IsFalse(session.IsGameOver);
   }
}
