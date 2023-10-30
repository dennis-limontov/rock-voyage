using System.Collections;
using UnityEngine;
using RVGC = RockVoyage.GameCharacteristics;

namespace RockVoyage
{
    public class Timer : MonoBehaviour
    {
        [SerializeField]
        private float _gameSpeed;

        private void Start()
        {
            SceneEvents.OnSceneLoaded += SceneLoadedHandler;
            SceneEvents.OnSceneUnloaded += SceneUnloadedHandler;
            Time.timeScale = _gameSpeed;
            StartCoroutine(StartGameTime());
        }

        private void SceneUnloadedHandler()
        {
            Time.timeScale = _gameSpeed;
        }

        private void SceneLoadedHandler()
        {
            Time.timeScale = 1;
        }

        private IEnumerator StartGameTime()
        {
            while (true)
            {
                yield return new WaitForSeconds(60f);
                RVGC.ClockDate = RVGC.ClockDate.AddMinutes(1);
            }
        }

        public void OnDestroy()
        {
            SceneEvents.OnSceneUnloaded -= SceneUnloadedHandler;
            SceneEvents.OnSceneLoaded -= SceneLoadedHandler;
        }
    }
}