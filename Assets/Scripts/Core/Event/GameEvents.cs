using System;

public class GameEvents
{
   public static event Action OnGameOver;
   public static event Action OnGameRestart;
   public static event Action<int> OnUpdateScore;

   public static void TriggerGameOver()
   {
      OnGameOver?.Invoke();
   }

   public static void TriggerGameRestart()
   {
      OnGameRestart?.Invoke();
   }

   public static void TriggerUpdateScore(int score)
   {
      OnUpdateScore?.Invoke(score);
   }
}
