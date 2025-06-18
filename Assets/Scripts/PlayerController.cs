using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D playerRb;

   [SerializeField]private bool isOnGround;
   [SerializeField]private float jumpForce = 10f;
   
   public bool gameOver;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      playerRb = GetComponent<Rigidbody2D>();
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
      {
         playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         isOnGround = false;
      }
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("Ground"))
        {
         isOnGround = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
      {
         gameOver = true;
         Debug.Log("Game Over");
      }
    }
}
