﻿using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class LevelComplete : MonoBehaviour
    {
        public string NextLevel;
        public Player player;
        private AudioSource Victory;

        // Use this for initialization
        void Start()
        {
            Victory = GetComponent<AudioSource>();
        }

        void OnTriggerEnter()
        {
            player.LevelComplete();
            Victory.Play();
        }

        public void PlayNextLevel()
        {
            Application.LoadLevel(NextLevel);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}