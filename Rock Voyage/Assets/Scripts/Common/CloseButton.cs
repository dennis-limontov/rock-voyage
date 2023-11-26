using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class CloseButton : UIBase
    {
        public void OnClick()
        {
            MapEvents.OnScenePreUnloaded?.Invoke(houseInfo);
            SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            GameCharacteristics.MapInfo.MapObjects.SetActive(true);
        }
    }
}