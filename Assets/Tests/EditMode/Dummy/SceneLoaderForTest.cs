using UnityEngine;

public class SceneLoaderForTest : ISceneLoader
{
   public bool SceneLoaded { get; private set; } = false;
   public void Restart()
   {
      Time.timeScale = 1f;
      SceneLoaded = true;
   }
}
