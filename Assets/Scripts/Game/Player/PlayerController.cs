using UnityEngine;

public class PlayerController : MonoBehaviour
{
   private Rigidbody2D playerRb;
   private Animator playerAnimator;

   [SerializeField] private bool isOnGround;
   [SerializeField] private float jumpForce = 10f;
   private bool isGameOver = false;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      GameEvents.OnGameOver += HandleGameOver;

      playerRb = GetComponent<Rigidbody2D>();
      playerAnimator = GetComponent<Animator>();
   }

   private void OnDestroy()
   {
      GameEvents.OnGameOver -= HandleGameOver;
   }

   // Update is called once per frame
   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
      {
         playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
         isOnGround = false;
         playerAnimator.SetTrigger("Jump_trig");
         playerAnimator.SetBool("Jump_b", true);
      }
      if (Input.GetKeyDown(KeyCode.R))
      {
         GameEvents.TriggerGameRestart();
      }
   }

   private void OnCollisionEnter2D(Collision2D collision)
   {
      if (collision.gameObject.CompareTag("Ground"))
      {
         isOnGround = true;
         playerAnimator.SetBool("Jump_b", false);
      }
      else if (collision.gameObject.CompareTag("Obstacle"))
      {
         GameEvents.TriggerGameOver();
         playerAnimator.SetBool("Death_b", true);
         playerAnimator.SetFloat("Speed_f", 0);
      }
   }

   void HandleGameOver()
   {
      isGameOver = true;
   }
}
