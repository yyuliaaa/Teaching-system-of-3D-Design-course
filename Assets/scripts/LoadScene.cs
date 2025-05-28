using UnityEngine;
using UnityEngine.SceneManagement;
namespace Sample.EquipmentDismantling
{
    public class LoadScene:MonoBehaviour
    {
        public void LoadSceneDo(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
