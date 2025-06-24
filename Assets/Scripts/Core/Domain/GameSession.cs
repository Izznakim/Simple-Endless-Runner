public class GameSession
{
   public bool IsGameOver { get; private set; }
   public float Score { get; private set; }

   public void AddScore(float deltaTime)
   {
      if (!IsGameOver)
      {
         Score += deltaTime;
      }
   }

   public void EndGame()
   {
      IsGameOver = true;
   }

   public void Reset()
   {
      Score = 0;
      IsGameOver = false;
   }
}
