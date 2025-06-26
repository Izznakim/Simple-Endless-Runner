using NUnit.Framework;

public class GameEventTests
{
   private bool gameOverCalled;
   private bool gameRestartCalled;
   private int lastScore;

   [SetUp]
   public void SetUp()
   {
      gameOverCalled = false;
      gameRestartCalled = false;
      lastScore = -1;
   }

   [Test]
   public void TriggerGameOverShouldInvokeOnGameOver()
   {
      GameEvents.OnGameOver += HandleGameOver;
      GameEvents.TriggerGameOver();
      GameEvents.OnGameOver -= HandleGameOver;
      Assert.IsTrue(gameOverCalled);
   }

   [Test]
   public void TriggerGameRestartShouldInvokeOnGameRestart()
   {
      GameEvents.OnGameRestart += HandleGameRestart;
      GameEvents.TriggerGameRestart();
      GameEvents.OnGameRestart -= HandleGameRestart;
      Assert.IsTrue(gameRestartCalled);
   }

   [Test]
   public void TriggerUpdateScoreShouldInvokeOnUpdateScoreWithCorrectValue()
   {
      GameEvents.OnUpdateScore += HandleUpdateScore;
      GameEvents.TriggerUpdateScore(100);
      GameEvents.OnUpdateScore -= HandleUpdateScore;
      Assert.AreEqual(100, lastScore);
   }

   void HandleGameOver() => gameOverCalled = true;
   void HandleGameRestart() => gameRestartCalled = true;
   void HandleUpdateScore(int score) => lastScore = score;
}
