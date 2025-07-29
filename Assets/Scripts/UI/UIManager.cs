using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour, IUIManager
{
   public TextMeshProUGUI scoreText;
   public GameObject retryText;

   public void UpdateScore(int score)
   {
      scoreText.text = "Score: " + score;
   }

   public void ShowGameOver()
   {
      retryText.SetActive(true);
   }
}
