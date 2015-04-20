using Assets.Scripts.ObjectScripts;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class InputHandler {
        public Player.PlayerDirection checkInput()
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                return Player.PlayerDirection.Up;
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                return Player.PlayerDirection.Down;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                return Player.PlayerDirection.Left;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                return Player.PlayerDirection.Right;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                return Player.PlayerDirection.Restart;
            }

            return 0;
        }
    }
}
