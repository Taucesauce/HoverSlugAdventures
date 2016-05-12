using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class LevelStart : MonoBehaviour
    {

        public Player player;
        // Use this for initialization
        void Start()
        {


        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter()
        {
            if(!player.GameStart)
            {
                player.StartGame();
            }
        }
    }
}