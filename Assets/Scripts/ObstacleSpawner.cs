using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   public GameObject obstacle;
   private PlayerController playerController;

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
      /*if (playerController.gameOver == false)
      {
         Instantiate(obstacle, new Vector2(transform.position.x + 11, -3f), obstacle.transform.rotation);
      }*/
      Instantiate(obstacle, new Vector2(transform.position.x + 11, -3f), obstacle.transform.rotation);
   }
}
