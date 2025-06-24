using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   public GameObject obstacle;

   private readonly float startDelay = 2;
   private readonly float repeatRate = 2;
   private bool isGameOver = false;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      GameEvents.OnGameOver += HandleGameOver;
      InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
   }

   private void SpawnObstacle()
   {
      if (!isGameOver)
      {
         Instantiate(obstacle, new Vector2(transform.position.x + 11, -3.09f), obstacle.transform.rotation);
      }
   }

   private void OnDestroy()
   {
      GameEvents.OnGameOver -= HandleGameOver;
   }

   void HandleGameOver()
   {
      isGameOver = true;
   }
}
