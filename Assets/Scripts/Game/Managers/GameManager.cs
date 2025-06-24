
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

   private GameUseCase _gameUseCase;

   private void Awake()
   {
      instance = this;
      _gameUseCase = new GameUseCase(new GameSession());
   }

   // Update is called once per frame
   void Update()
   {
      if (!_gameUseCase.IsGameOver())
      {
         _gameUseCase.AddScore(Time.deltaTime);
         GameEvents.TriggerUpdateScore((int)_gameUseCase.GetScore());
      }
   }

   private void OnEnable()
   {
      GameEvents.OnGameOver += GameOver;
      GameEvents.OnGameRestart += Restart;
   }

   private void OnDisable()
   {
      GameEvents.OnGameOver -= GameOver;
      GameEvents.OnGameRestart -= Restart;
   }

   public void GameOver()
   {
      _gameUseCase.GameOver();
   }

   public void Restart()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene(0);
   }

   public bool IsGameOver() => _gameUseCase.IsGameOver();
}
