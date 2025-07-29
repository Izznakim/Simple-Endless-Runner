
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   [SerializeField] private MonoBehaviour uiManagerSource;
   private IGameUseCase _gameUseCase;
   private IUIManager _uiManager;
   private ISceneLoader _sceneLoader;

   private void Awake()
   {
      _gameUseCase = new GameUseCase(new GameSession());
      _uiManager = uiManagerSource as IUIManager;
      _sceneLoader = new SceneLoader();
   }

   public void SetUIManager(UIManager uiManager)
   {
      _uiManager = uiManager;
   }

   // Update is called once per frame
   void Update()
   {
      if (!_gameUseCase.IsGameOver())
      {
         _gameUseCase.AddScore(Time.deltaTime);
         _uiManager.UpdateScore((int)_gameUseCase.GetScore());
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
      _uiManager.ShowGameOver();
   }

   public void Restart()
   {
      _sceneLoader.Restart();
   }

   public bool IsGameOver() => _gameUseCase.IsGameOver();
}
