using UnityEngine;
using UnityEngine.Rendering;

public class GameManagerForTest
{
   private readonly IGameUseCase _gameUseCase;
   private readonly IUIManager _uiManager;
   private readonly ISceneLoader _sceneLoader;

   // Mirip dengan Awake() untuk inisiasi?
   public GameManagerForTest(IGameUseCase gameUseCase, IUIManager uiManager, ISceneLoader sceneLoader)
   {
      _gameUseCase = gameUseCase;
      _uiManager = uiManager;
      _sceneLoader = sceneLoader;
   }

   public void Tick(float deltaTime)
   {
      if (!_gameUseCase.IsGameOver())
      {
         _gameUseCase.AddScore(deltaTime);
         _uiManager.UpdateScore((int)_gameUseCase.GetScore());
      }
   }

   public void GameOver()
   {
      _gameUseCase.GameOver();
      _uiManager.ShowGameOver();
   }

   public void Restart()
   {
      _sceneLoader.Restart();
   }

   public bool IsGameOver() => _gameUseCase.IsGameOver();
}
