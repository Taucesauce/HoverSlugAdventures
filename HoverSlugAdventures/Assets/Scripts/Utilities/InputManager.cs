using Assets.Scripts.ObjectScripts;
using UnityEngine;

namespace Assets.Scripts.Utilities
{
    public class InputHandler {
        Vector3 startPos;
        Vector3 currentPos;
        Vector3 distance;

        public Player.PlayerDirection checkInput()
        {
            //Keyboard Controls
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

            if(Input.GetKeyDown(KeyCode.P))
            {
                return Player.PlayerDirection.Party;
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            //Mouse/Swipe Controls

            if(Input.GetMouseButtonDown(0))
            {
                startPos = Input.mousePosition;
                return 0;
            }
            else if(Input.GetMouseButton(0)) 
            {
                currentPos = Input.mousePosition;
                distance = currentPos - startPos; 
                return 0;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                if(Mathf.Abs(distance.x) > Mathf.Abs(distance.y)) //Arbitrary magnitude, needs to relate to screen size but w/e.
                {
                    if(Mathf.Abs(distance.x)*3 > Screen.width)
                    {
                        if (distance.x > 0)
                        {
                            return Player.PlayerDirection.Right;
                        }
                        else if (distance.x < 0)
                        {
                            return Player.PlayerDirection.Left;
                        }
                    }
                }
                else
                {
                    if(Mathf.Abs(distance.y)*3 > Screen.height)
                    {
                        if (distance.y > 0)
                        {
                            return Player.PlayerDirection.Up;
                        }
                        else if (distance.y < 0)
                        {
                            return Player.PlayerDirection.Down;
                        }
                    }
                }
            }

            return 0;
        }
    }
}
