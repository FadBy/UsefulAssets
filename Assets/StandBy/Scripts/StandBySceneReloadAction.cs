using Logger;
using UnityEngine.SceneManagement;

namespace StandBy
{
    public class StandBySceneReloadAction : IStandByAction
    {
        public void Perform()
        {
            GameLogger.Instance.LogInfo("SceneLoader", $"Reloading scene {SceneManager.GetActiveScene()}");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}