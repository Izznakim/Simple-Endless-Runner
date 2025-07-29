using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : ISceneLoader
{
   public void Restart()
   {
      Time.timeScale = 1f;
      SceneManager.LoadScene(0);
   }
}
