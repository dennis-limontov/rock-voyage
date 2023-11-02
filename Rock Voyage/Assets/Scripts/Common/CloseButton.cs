using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class CloseButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            GameCharacteristics.MapInfo.MapObjects.SetActive(true);
        }
    }
}