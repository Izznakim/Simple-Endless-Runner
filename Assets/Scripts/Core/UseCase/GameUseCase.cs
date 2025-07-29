public class GameUseCase : IGameUseCase
{
   private GameSession _session;

   public GameUseCase(GameSession session)
   {
      _session = session;
   }

   public float GetScore() => _session.Score;
   public bool IsGameOver() => _session.IsGameOver;

   public void AddScore(float deltaTime) => _session.AddScore(deltaTime);
   public void GameOver() => _session.EndGame();
   public void Reset() => _session.Reset();
}
