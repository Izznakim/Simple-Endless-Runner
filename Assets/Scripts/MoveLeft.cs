using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   [SerializeField] private float speed = 0.1f;
   private float botBound = -7;


   // Update is called once per frame
   void Update()
   {
      if (!GameManager.instance.isGameOver)
      {
         transform.Translate(Vector2.left * Time.deltaTime * speed);
      }

      if (transform.position.y < botBound)
      {
         Destroy(gameObject);
      }
   }
}
