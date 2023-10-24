using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RockVoyage
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _music;

        private float _perfomanceQuality = 1f;

        private void Start()
        {
            Events.OnCountdownEnded += CountdownEndedHandler;
            Events.OnWrongNotePlayed += WrongNotePlayedHandler;
        }

        private void CountdownEndedHandler()
        {
            _music.Play();
        }

        private void WrongNotePlayedHandler(float penalty)
        {
            _perfomanceQuality -= penalty;
        }

        private void OnDestroy()
        {
            Events.OnCountdownEnded -= CountdownEndedHandler;
        }
    }
}