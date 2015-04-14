using System;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ObjectScripts
{
    public class Player : MonoBehaviour
    {
        public enum PlayerDirection { Left = 1, Right = 2, Up = 3, Down = 4 }

        //Player Variables:
        private int moves;
        public Text MovesDisplay;
        public Room CurrentRoom;
        private Tile currentTile;
        private const int tileOffset = 1;
        private InputHandler input;
        public Tile CurrentTile { get { return currentTile; } }

        // Use this for initialization
        void Start ()
        {
            input = new InputHandler();
            currentTile = gameObject.AddComponent<Tile>();
            currentTile = CurrentRoom.StartingTile;
            moves = CurrentRoom.movesAllowed;
            MovesDisplay.text = moves.ToString();
        }
	
        // Update is called once per frame
        void Update ()
        {
            MovesDisplay.text = moves.ToString();
            if(moves < 3)
            {
                MovesDisplay.color = Color.red;
            }
            else
            {
                MovesDisplay.color = Color.cyan;
            }
            currentTile = movePlayer(input.checkInput());
            transform.position = currentTile.TileCenter;
        }

        public void switchRoom(Room nextRoom)
        {
            CurrentRoom = nextRoom;
            currentTile = nextRoom.StartingTile;
            transform.position = currentTile.TileCenter;
        }

        public void AddMoves(int numMoves)
        {
            moves += numMoves;
        }
        
        Tile movePlayer(PlayerDirection direction)
        {
            if (moves > 0)
            {
                switch (direction)
                {
                    case PlayerDirection.Left:
                        if (checkTile((int) currentTile.TileIndex.x - 1,
                            (int) currentTile.TileIndex.y))
                        {
                            currentTile = CurrentRoom.floorLayout.Layout[(int) currentTile.TileIndex.x - 1,
                                (int) currentTile.TileIndex.y];
                            moves--;
                        }
                        break;
                    case PlayerDirection.Right:
                        if (checkTile((int)currentTile.TileIndex.x + 1,
                            (int)currentTile.TileIndex.y))
                        {
                            currentTile = CurrentRoom.floorLayout.Layout[(int)currentTile.TileIndex.x + 1,
                                (int)currentTile.TileIndex.y];
                            moves--;
                        }
                        break;
                    case PlayerDirection.Up:
                        if (checkTile((int)currentTile.TileIndex.x,
                            (int)currentTile.TileIndex.y - 1))
                        {
                            currentTile = CurrentRoom.floorLayout.Layout[(int)currentTile.TileIndex.x,
                                (int)currentTile.TileIndex.y - 1];
                            moves--;
                        }
                        break;
                    case PlayerDirection.Down:
                        if (checkTile((int)currentTile.TileIndex.x,
                           (int)currentTile.TileIndex.y + 1))
                        {
                            currentTile = CurrentRoom.floorLayout.Layout[(int)currentTile.TileIndex.x,
                                (int)currentTile.TileIndex.y + 1];
                            moves--;
                        }
                        break;
                    default:
                        return currentTile;
                }
                return currentTile;
            }
            return currentTile;
        }

        bool checkTile(int xIndex, int yIndex)
        {
            bool xPassed = false;
            bool yPassed = false;

            if (xIndex >= 0 && xIndex <= 4)
                xPassed = true;

            if (xIndex >= 0 && xIndex <= 4)
                yPassed = true;

            return (xPassed && yPassed);
        }
    }
}
