using System;

public class GameEvents
{
   public static event Action OnGameOver;
   public static event Action OnGameRestart;

   public static void TriggerGameOver()
   {
      OnGameOver?.Invoke();
   }

   public static void TriggerGameRestart()
   {
      OnGameRestart?.Invoke();
   }
}
