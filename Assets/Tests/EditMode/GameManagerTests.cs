using NUnit.Framework;
using UnityEngine;

public class GameManagerTests
{
   private GameManagerForTest _gameManager;
   private GameUseCaseForTest _gameUseCase;
   private UIManagerForTest _uiManager;
   private SceneLoaderForTest _sceneLoader;

   [SetUp]
   public void Setup()
   {
      _gameUseCase = new GameUseCaseForTest();
      _uiManager = new UIManagerForTest();
      _sceneLoader = new SceneLoaderForTest();

      _gameManager = new GameManagerForTest(_gameUseCase, _uiManager, _sceneLoader);
   }

   [Test]
   public void Tick_AddsScore_WhenNotGameOver()
   {
      float deltaTime = 1.5f;

      _gameManager.Tick(deltaTime);

      Assert.AreEqual(deltaTime, _gameUseCase.ScoreAdded);
      Assert.AreEqual((int)deltaTime, _uiManager.UpdatedScore);
   }

   [Test]
   public void Tick_DoesNotAddScore_WhenGameOver()
   {
      _gameUseCase = new GameUseCaseForTest(isGameOver: true);
      _gameManager = new GameManagerForTest(_gameUseCase, _uiManager, _sceneLoader);

      float deltaTime = 2f;
      _gameManager.Tick(deltaTime);

      Assert.AreEqual(0f, _gameUseCase.ScoreAdded);
      Assert.AreEqual(0, _uiManager.UpdatedScore);
   }

   [Test]
   public void GameOver_CallsUseCaseAndUI()
   {
      _gameManager.GameOver();

      Assert.IsTrue(_gameUseCase.GameOverCalled);
      Assert.IsTrue(_uiManager.ShowGameOverCalled);
   }

   [Test]
   public void Restart_CallsSceneLoader()
   {
      _gameManager.Restart();

      Assert.IsTrue(_sceneLoader.SceneLoaded);
   }

   [Test]
   public void IsGameOver_ReturnsCorrectStatus()
   {
      Assert.IsFalse(_gameManager.IsGameOver());

      _gameUseCase.GameOver();
      Assert.IsTrue(_gameManager.IsGameOver());
   }
}
