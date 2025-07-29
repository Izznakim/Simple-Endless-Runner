using NUnit.Framework;

public class GameEventTests
{
   private bool gameOverCalled;
   private bool gameRestartCalled;

   [SetUp]
   public void SetUp()
   {
      gameOverCalled = false;
      gameRestartCalled = false;
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
   public void MultipleSubscriptionShouldOnlyTriggerOnceEach()
   {
      int counter = 0;
      void Handler() => counter++;

      GameEvents.OnGameOver += Handler;
      GameEvents.OnGameOver += Handler;
      GameEvents.TriggerGameOver();
      GameEvents.OnGameOver -= Handler;
      GameEvents.OnGameOver -= Handler;

      Assert.AreEqual(2, counter);
   }

   void HandleGameOver() => gameOverCalled = true;
   void HandleGameRestart() => gameRestartCalled = true;
}
