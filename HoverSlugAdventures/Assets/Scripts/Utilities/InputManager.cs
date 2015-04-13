using Assets.Scripts.ObjectScripts;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class InputHandler {
        public Player.PlayerDirection checkInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                return Player.PlayerDirection.Up;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                return Player.PlayerDirection.Down;
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                return Player.PlayerDirection.Left;
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                return Player.PlayerDirection.Right;
            }

            return 0;
        }
    }
}
