using System;
using System.Collections.Generic;
using Assets.Scripts.ObjectScripts;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class Grid : MonoBehaviour
    {
        //Data Structure Variables

        protected int gridWidth;
        protected int gridHeight;
        public Tile[,] FloorTiles { get; private set; }
        private GameObject[] tempGetComponentArray;
        public Texture[] TileTextures;
        public Switch[] switches;
        private int switchNum = 0;
        private List<Tile> switchList;
        private AudioSource teleportSound;
        public ObjectManipulation[] interactiveObjects;
 
        public int SwitchNum
        {
            get { return switchNum; }
        }

        private int numSwitches;
        // Use this for initialization
        protected virtual void Awake()
        {
            gridWidth = 5;
            gridHeight = 5;
            switchList = new List<Tile>();
            teleportSound = GetComponent<AudioSource>();
        }

        private void Start()
        {
            setTiles();
        }
        // Update is called once per frame
        private void Update()
        {

        }
        protected void setTiles()
        {
            FloorTiles = new Tile[gridWidth, gridHeight];
            Vector2 tempVector = Vector2.zero;
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    tempVector.x = x;
                    tempVector.y = y;

                    FloorTiles[x, y] = this.GetComponentsInChildren<Tile>()[(gridHeight * y + x)];
                    FloorTiles[x, y].TilePos = this.GetComponentsInChildren<Tile>()[gridHeight * y + x].transform.position;
                    FloorTiles[x, y].TileIndex = tempVector;
                    FloorTiles[x, y].GetComponent<Renderer>().material.mainTexture =
                        TileTextures[(int)FloorTiles[x, y].GetComponent<Tile>().currentType];
                    if (FloorTiles[x, y].currentType == Tile.TileType.Switch)
                    {
                        switchNum++;
                        switchList.Add(FloorTiles[x, y]);
                    }
                }
            }
            numSwitches = switchNum;
        }
        public Tile GetDestinationTile(Tile currentTile, Player.PlayerDirection direction)
        {
            Tile tempTile = currentTile;

            switch (direction)
            {
                case Player.PlayerDirection.Left:
                    if (checkGrid((int) currentTile.TileIndex.x - 1,
                        (int) currentTile.TileIndex.y))
                    {
                        if (checkTile(FloorTiles[(int) currentTile.TileIndex.x - 1,
                            (int) currentTile.TileIndex.y]))
                            currentTile = FloorTiles[(int) currentTile.TileIndex.x - 1,
                                (int) currentTile.TileIndex.y];
                    }
                    break;
                case Player.PlayerDirection.Right:
                    if (checkGrid((int) currentTile.TileIndex.x + 1,
                        (int) currentTile.TileIndex.y))
                    {
                        if (checkTile(FloorTiles[(int) currentTile.TileIndex.x + 1,
                            (int) currentTile.TileIndex.y]))
                            currentTile = FloorTiles[(int) currentTile.TileIndex.x + 1,
                                (int) currentTile.TileIndex.y];
                    }
                    break;
                case Player.PlayerDirection.Up:
                    if (checkGrid((int) currentTile.TileIndex.x,
                        (int) currentTile.TileIndex.y - 1))
                    {
                        if (checkTile(FloorTiles[(int) currentTile.TileIndex.x,
                            (int) currentTile.TileIndex.y - 1]))
                            currentTile = FloorTiles[(int) currentTile.TileIndex.x,
                                (int) currentTile.TileIndex.y - 1];
                    }
                    break;
                case Player.PlayerDirection.Down:
                    if (checkGrid((int) currentTile.TileIndex.x,
                        (int) currentTile.TileIndex.y + 1))
                    {
                        if (checkTile(FloorTiles[(int) currentTile.TileIndex.x,
                            (int) currentTile.TileIndex.y + 1]))
                            currentTile = FloorTiles[(int) currentTile.TileIndex.x,
                                (int) currentTile.TileIndex.y + 1];
                    }
                    break;
            }
            if (currentTile.currentType == Tile.TileType.Teleport && tempTile != currentTile)
            {
                teleportSound.Play();
                return currentTile.TileTarget;
            }
            if (currentTile.currentType == Tile.TileType.Switch && tempTile != currentTile)
            {
                switchNum--;
                Debug.Log(switchNum);
                FloorTiles[(int)currentTile.TileIndex.x,(int)currentTile.TileIndex.y].TileTarget.currentType = Tile.TileType.Open;
                FloorTiles[(int)currentTile.TileIndex.x, (int)currentTile.TileIndex.y].currentType = Tile.TileType.Open;
            }
            return currentTile;
        }

        protected bool checkGrid(int xIndex, int yIndex)
        {
            bool xPassed = false;
            bool yPassed = false;

            if (xIndex >= 0 && xIndex <= gridHeight-1)
                xPassed = true;

            if (xIndex >= 0 && xIndex <= gridHeight-1)
                yPassed = true;

            return (xPassed && yPassed);
        }

        protected bool checkTile(Tile tileToCheck)
        {
            return tileToCheck.currentType != Tile.TileType.Closed;
        }

        public void ResetRoom()
        {
            resetTiles();
            resetObjects();
            resetSwitches();
            switchNum = numSwitches;
        }

        protected void resetTiles()
        {
            foreach (Tile tile in FloorTiles)
            {
                if (switchList.Contains(tile))
                {
                    tile.currentType = Tile.TileType.Switch;
                    tile.TileTarget.currentType = Tile.TileType.Closed;
                }
            }
        }

        protected void resetObjects()
        {
            foreach (ObjectManipulation obj in interactiveObjects)
            {
                obj.Reset();
            }
        }

        protected void resetSwitches()
        {
            foreach(Switch s in switches)
            {
                s.Reset();
            }
        }
    }
}