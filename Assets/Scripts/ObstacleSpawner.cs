using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   public GameObject obstacle;
   private PlayerController playerController;
   private Vector2 spawnPosition = new Vector2(11, -3.6f);

   private readonly float startDelay = 2;
   private readonly float repeatRate = 2;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
      playerController = GameObject.Find("Player").GetComponent<PlayerController>();
   }

   private void SpawnObstacle()
   {
      if (playerController.gameOver == false)
      {
         Instantiate(obstacle, spawnPosition, obstacle.transform.rotation);
      }
   }
}
