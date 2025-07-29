using UnityEngine;

public class UIManagerForTest : IUIManager
{
   public int UpdatedScore { get; private set; }
   public bool ShowGameOverCalled { get; private set; } = false;

   public void UpdateScore(int score)
   {
      UpdatedScore = score;
   }

   public void ShowGameOver()
   {
      ShowGameOverCalled = true;
   }
}
