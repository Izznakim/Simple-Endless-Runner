using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   public bool isGameOver = false;
   public float score = 0f;

   private void Awake()
   {
      instance = this;
   }

   // Update is called once per frame
   void Update()
   {
      if (!isGameOver)
      {
         score += Time.deltaTime;
         UIManager.Instance.UpdateScore((int)score);
      }
   }

   public void GameOver()
   {
      isGameOver = true;
      UIManager.Instance.ShowGameOver();
   }

   public void Restart()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene(0);
   }
}
