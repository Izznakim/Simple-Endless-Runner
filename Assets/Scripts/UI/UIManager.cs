using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public TextMeshProUGUI scoreText;
   public GameObject retryText;

   private void OnEnable()
   {
      GameEvents.OnGameOver += ShowGameOver;
      GameEvents.OnUpdateScore += UpdateScore;
   }

   private void OnDisable()
   {
      GameEvents.OnGameOver -= ShowGameOver;
      GameEvents.OnUpdateScore -= UpdateScore;
   }

   public void UpdateScore(int score)
   {
      scoreText.text = "Score: " + score;
   }

   public void ShowGameOver()
   {
      retryText.SetActive(true);
   }
}
