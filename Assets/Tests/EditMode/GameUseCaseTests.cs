using NUnit.Framework;

public class GameUseCaseTests
{
   private GameSession session;
   private GameUseCase useCase;

   [SetUp]
   public void SetUp()
   {
      session = new GameSession();
      useCase = new GameUseCase(session);
   }

   // A Test behaves as an ordinary method
   [Test]
   public void GetScoreShouldReturnScoreFromSession()
   {
      session.AddScore(2f);
      Assert.AreEqual(2f, useCase.GetScore());
   }

   [Test]
   public void IsGameOverShouldNotReturnFalseInitially()
   {
      Assert.IsFalse(useCase.IsGameOver());
   }

   [Test]
   public void AddScoreShouldWorkWhenGameNotOver()
   {
      useCase.AddScore(1f);
      Assert.AreEqual(1f, useCase.GetScore());
   }

   [Test]
   public void AddScoreShouldNotWorkWhenGameIsOver()
   {
      useCase.GameOver();
      useCase.AddScore(1f);
      Assert.AreEqual(0f, useCase.GetScore());
   }

   [Test]
   public void GameOverShouldSetIsGameOverTrue()
   {
      useCase.GameOver();
      Assert.IsTrue(useCase.IsGameOver());
   }

   [Test]
   public void ResetShouldResetScoreAndGameOver()
   {
      useCase.AddScore(5f);
      useCase.GameOver();
      useCase.Reset();

      Assert.AreEqual(0f,useCase.GetScore());
      Assert.IsFalse(useCase.IsGameOver());
   }

   [Test]
   public void AddScoreThenResetShouldResetCorrectly()
   {
      useCase.AddScore(10f);
      useCase.Reset();

      Assert.AreEqual(0f, useCase.GetScore());
      Assert.IsFalse(useCase.IsGameOver());
   }
}
