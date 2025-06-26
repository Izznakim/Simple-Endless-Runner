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
      // Use the Assert class to test conditions
      /*var session = new GameSession();
      var useCase = new GameUseCase(session);*/

      session.AddScore(2f);
      Assert.AreEqual(2f, useCase.GetScore());
   }

   [Test]
   public void IsGameOverShouldNotReturnFalseInitially()
   {
      /*var session = new GameSession();
      var useCase = new GameUseCase(session);*/

      Assert.IsFalse(useCase.IsGameOver());
   }

   [Test]
   public void AddScoreShouldWorkWhenGameNotOver()
   {
      /*var session = new GameSession();
      var useCase = new GameUseCase(session);*/

      useCase.AddScore(1f);
      Assert.AreEqual(1f, useCase.GetScore());
   }

   [Test]
   public void AddScoreShouldNotWorkWhenGameIsOver()
   {
      /*var session = new GameSession();
      var useCase = new GameUseCase(session);*/

      useCase.GameOver();
      useCase.AddScore(1f);
      Assert.AreEqual(0f, useCase.GetScore());
   }

   [Test]
   public void GameOverShouldSetIsGameOverTrue()
   {
      /*var session = new GameSession();
      var useCase = new GameUseCase(session);*/

      useCase.GameOver();
      Assert.IsTrue(useCase.IsGameOver());
   }

   [Test]
   public void ResetShouldResetScoreAndGameOver()
   {
      /*var session = new GameSession();
      var useCase = new GameUseCase(session);*/

      useCase.AddScore(5f);
      useCase.GameOver();
      useCase.Reset();

      Assert.AreEqual(0f,useCase.GetScore());
      Assert.IsFalse(useCase.IsGameOver());
   }
}
