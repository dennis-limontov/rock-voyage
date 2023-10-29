using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RockVoyage
{
    public class CloseButton : MonoBehaviour
    {
        public void OnClick()
        {
            SceneManager.LoadScene(GameCharacteristics.MapInfo.MapName);
        }
    }
}