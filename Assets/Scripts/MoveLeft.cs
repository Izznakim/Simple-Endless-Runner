using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   private PlayerController playerController;

   [SerializeField] private float speed = 5;
   private float leftBound = -11;

   private void Start()
   {
      playerController = GameObject.Find("Player").GetComponent<PlayerController>();
   }

   // Update is called once per frame
   void Update()
   {
      if (!playerController.gameOver)
      {
         transform.Translate(Vector2.left * Time.deltaTime * speed);
      }

      if (transform.position.x < leftBound)
      {
         Destroy(gameObject);
      }
   }
}
