using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
   public static UIManager Instance;
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

   private void Awake()
   {
      Instance = this;
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
