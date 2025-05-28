using UnityEditor;
using UnityEngine;
namespace Sample.EquipmentDismantling
{
    public class QuitApp : MonoBehaviour
    {
        public void QuitProgram()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;

#else
                Application.Quit();
#endif
        }
    }
}
