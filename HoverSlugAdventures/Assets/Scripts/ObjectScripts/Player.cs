using System;
using System.IO;
using Assets.Scripts.Interfaces;
using Assets.Scripts.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.ObjectScripts
{
    public class Player : MonoBehaviour
    {
        public enum PlayerDirection { Left = 1, Right = 2, Up = 3, Down = 4, Restart = 5 }

        //Player Variables:
        private int moves;
        public int Moves { get { return moves; } }
        public NewRoom CurrentRoom;
        private Tile currentTile;
        public Tile CurrentTile { get { return currentTile; } }
        private Tile tempTile;
        private InputHandler input;
        private bool gameStart, levelCompleted;
        public bool LevelCompleted { get { return levelCompleted; } }
        public bool GameStart { get { return gameStart; } }
        void Awake()
        {
            input = new InputHandler();      
            levelCompleted = false;
            gameStart = false;
        }
        // Use this for initialization
        void Start ()
        {
            currentTile = CurrentRoom.StartingTile;
            moves = CurrentRoom.movesAllowed;
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (currentTile == null)
            {
                currentTile = CurrentRoom.StartingTile;
            }
            else
            {
                if(levelCompleted == false && gameStart == true)
                    currentTile = movePlayer(input.checkInput());
            }
            transform.position = currentTile.TilePos;
        }

        public void switchRoom(NewRoom nextRoom)
        {
            CurrentRoom = nextRoom;
            currentTile = nextRoom.StartingTile;
            transform.position = currentTile.TilePos;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        public void restartRoom()
        {
            switchRoom(CurrentRoom);
            moves = CurrentRoom.movesAllowed;
            CurrentRoom.FloorLayout.ResetRoom();
        }
        public void AddMoves(int numMoves)
        {
            moves += numMoves;
        }
        
        Tile movePlayer(PlayerDirection direction)
        {
            if (moves > 0)
            {
                tempTile = currentTile;
                currentTile = CurrentRoom.FloorLayout.GetDestinationTile(currentTile, direction);
                if (tempTile != currentTile)
                    moves--;   
            }

            switch (direction)
            {
                case PlayerDirection.Left:
                    transform.rotation = Quaternion.Euler(0,-90,0);
                    break;
                case PlayerDirection.Right:
                    transform.rotation = Quaternion.Euler(0, 90, 0);
                    break;
                case PlayerDirection.Up:
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    break;
                case PlayerDirection.Down:
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    break;
                case PlayerDirection.Restart:
                    currentTile = CurrentRoom.StartingTile;
                    restartRoom();
                    break;
            }

            return currentTile;
        }

        public void setMoves(int moveNum)
        {
            moves = moveNum;
        }

        public void StartGame()
        {
            gameStart = true;
            levelCompleted = false;
        }

        public void LevelComplete()
        {
            levelCompleted = true;
        }
    }
}
