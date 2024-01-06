using UnityEngine;

namespace RockVoyage
{
    public class ResetPlayerPrefs : MonoBehaviour
    {
        private void Awake()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
