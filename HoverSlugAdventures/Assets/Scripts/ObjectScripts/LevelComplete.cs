using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class LevelComplete : MonoBehaviour
    {
        public string NextLevel;
        public Player player;

        // Use this for initialization
        void Start()
        {
            
        }

        void OnTriggerEnter()
        {
            player.LevelComplete();
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