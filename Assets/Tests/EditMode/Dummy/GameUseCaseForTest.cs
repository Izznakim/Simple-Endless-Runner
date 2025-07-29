using UnityEngine;

public class GameUseCaseForTest : IGameUseCase
{
   private bool _isGameOver;
   public float ScoreAdded { get; private set; } = 0f;
   public bool GameOverCalled { get; private set; } = false;

   public GameUseCaseForTest(bool isGameOver = false)
   {
      _isGameOver = isGameOver;
   }

   public void AddScore(float deltaTime)
   {
      ScoreAdded += deltaTime;
   }

   public void GameOver()
   {
      GameOverCalled = true;
      _isGameOver = true;
   }

   public float GetScore() => ScoreAdded;

   public bool IsGameOver() => _isGameOver;

   public void Reset() { }
}
