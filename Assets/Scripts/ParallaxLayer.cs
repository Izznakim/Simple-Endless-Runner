using UnityEngine;

public class ParallaxLayer : MonoBehaviour
{
   public float scrollSpeed = 2f;
   public float width;

   // Start is called once before the first execution of Update after the MonoBehaviour is created
   void Start()
   {
      Sprite sprite = GetComponent<SpriteRenderer>().sprite;
      Texture2D texture = sprite.texture;

      width = GetComponent<SpriteRenderer>().bounds.size.x;
   }

   // Update is called once per frame
   void Update()
   {
      transform.Translate(Vector2.left * scrollSpeed * Time.deltaTime);

      if(transform.position.x < -width)
      {
         transform.position += new Vector3(width * 2f, 0, 0);
      }
   }
}
