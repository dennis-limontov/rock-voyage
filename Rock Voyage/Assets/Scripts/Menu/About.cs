using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class About : MonoBehaviour
    {
        public void OnBackClicked()
        {
            SceneManager.LoadScene(Constants.Scenes.MAIN_MENU);
        }
    }
}
