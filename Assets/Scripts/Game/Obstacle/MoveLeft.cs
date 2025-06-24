using UnityEngine;

public class MoveLeft : MonoBehaviour
{
   [SerializeField] private float speed = 0.1f;
   private float botBound = -7;
   private bool isGameOver = false;

   private void Start()
   {
      GameEvents.OnGameOver += HandleGameOver;
   }

   private void OnDestroy()
   {
      GameEvents.OnGameOver -= HandleGameOver;
   }

   void HandleGameOver()
   {
      isGameOver = true;
   }

   // Update is called once per frame
   void Update()
   {
      if (!isGameOver)
      {
         transform.Translate(Vector2.left * Time.deltaTime * speed);
      }

      if (transform.position.y < botBound)
      {
         Destroy(gameObject);
      }
   }
}
