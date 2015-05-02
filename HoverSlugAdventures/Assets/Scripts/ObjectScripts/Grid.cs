using System;
using Assets.Scripts.ObjectScripts;
using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class Grid : MonoBehaviour
    {
        //Data Structure Variables
        public Tile[,] FloorTiles { get; private set; }
        private GameObject[] tempGetComponentArray;
        public Texture[] TileTextures;
        private int switchNum = 0;
        public int SwitchNum { get { return switchNum; } }
        // Use this for initialization
        private void Awake()
        {
            FloorTiles = new Tile[5, 5];
            Vector2 tempVector = Vector2.zero;
            for (int y = 0; y < 5; y++)
            {
                for (int x = 0; x < 5; x++)
                {
                    tempVector.x = x;
                    tempVector.y = y;

                    FloorTiles[x, y] = this.GetComponentsInChildren<Tile>()[(5*y+x)];
                    FloorTiles[x, y].TilePos = this.GetComponentsInChildren<Tile>()[5*y + x].transform.position;
                    FloorTiles[x, y].TileIndex = tempVector;
                    FloorTiles[x, y].GetComponent<Renderer>().material.mainTexture =
                        TileTextures[(int) FloorTiles[x, y].GetComponent<Tile>().currentType];
                    if(FloorTiles[x, y].currentType == Tile.TileType.Switch)
                    {
                        switchNum++;
                    }
                }
            }
        }

        // Update is called once per frame
        private void Update()
        {

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
                        if (checkTile(FloorTiles[(int)currentTile.TileIndex.x - 1,
                            (int)currentTile.TileIndex.y]))
                        currentTile = FloorTiles[(int)currentTile.TileIndex.x - 1, 
                            (int)currentTile.TileIndex.y];
                    }
                    break;
                case Player.PlayerDirection.Right:
                    if (checkGrid((int)currentTile.TileIndex.x + 1,
                        (int)currentTile.TileIndex.y))
                    {
                        if (checkTile(FloorTiles[(int)currentTile.TileIndex.x + 1,
                            (int)currentTile.TileIndex.y]))
                            currentTile = FloorTiles[(int)currentTile.TileIndex.x + 1,
                                (int)currentTile.TileIndex.y];
                    }
                    break;
                case Player.PlayerDirection.Up:
                    if (checkGrid((int)currentTile.TileIndex.x,
                        (int)currentTile.TileIndex.y - 1))
                    {
                        if (checkTile(FloorTiles[(int)currentTile.TileIndex.x,
                            (int)currentTile.TileIndex.y - 1]))
                            currentTile = FloorTiles[(int)currentTile.TileIndex.x,
                                (int)currentTile.TileIndex.y - 1];
                    }
                    break;
                case Player.PlayerDirection.Down:
                    if (checkGrid((int)currentTile.TileIndex.x,
                        (int)currentTile.TileIndex.y + 1))
                    {
                        if (checkTile(FloorTiles[(int)currentTile.TileIndex.x,
                            (int)currentTile.TileIndex.y + 1]))
                            currentTile = FloorTiles[(int)currentTile.TileIndex.x,
                                (int)currentTile.TileIndex.y + 1];
                    }
                    break;
            }
            if(currentTile.currentType == Tile.TileType.Teleport && tempTile != currentTile)
            {
                return currentTile.TileTarget;
            }
            if (currentTile.currentType == Tile.TileType.Switch && tempTile != currentTile)
            {
                switchNum--;
                Debug.Log(switchNum);
                currentTile.TileTarget.currentType = Tile.TileType.Open;
                currentTile.currentType = Tile.TileType.Open;
            }
            return currentTile;
        }

        bool checkGrid(int xIndex, int yIndex)
        {
            bool xPassed = false;
            bool yPassed = false;

            if (xIndex >= 0 && xIndex <= 4)
                xPassed = true;

            if (xIndex >= 0 && xIndex <= 4)
                yPassed = true;

            return (xPassed && yPassed);
        }

        bool checkTile(Tile tileToCheck)
        {
            return tileToCheck.currentType != Tile.TileType.Closed;
        }
    }
}