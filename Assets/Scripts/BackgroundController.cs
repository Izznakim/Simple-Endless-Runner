using UnityEngine;

public class BackgroundController : MonoBehaviour
{
   public Sprite[] Layer_Sprites;
   private GameObject[] Layer_Object = new GameObject[5];

   void Start()
   {
      for (int i = 0; i < Layer_Object.Length; i++)
      {
         Layer_Object[i] = GameObject.Find("Layer_" + i);
      }
   }
}
