using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
   public GameObject obstacle;

   private readonly float startDelay = 2;
   private readonly float repeatRate = 2;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
   }

   private void SpawnObstacle()
   {
         Instantiate(obstacle, new Vector2(transform.position.x + 11, -3.09f), obstacle.transform.rotation);
   }
}
