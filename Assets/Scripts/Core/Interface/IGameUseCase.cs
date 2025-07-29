using UnityEngine;

public interface IGameUseCase
{
   float GetScore();
   bool IsGameOver();
   void AddScore(float deltaTime);
   void GameOver();
   void Reset();
}
