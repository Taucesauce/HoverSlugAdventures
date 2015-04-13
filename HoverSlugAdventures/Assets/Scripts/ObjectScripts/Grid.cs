using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class Grid : MonoBehaviour
    {
        private Vector3 gridOrigin;
        public Tile[,] Layout;
        private const int gridWidth = 5;
        private const int gridHeight = 5;
        private List<Tile> neighbors;
 
        // Use this for initialization
        void Awake()
        {
            gridOrigin = this.transform.position + new Vector3(-50, 0, 50);
            Layout = new Tile[gridWidth,gridHeight];
            setTiles();
        }
	
        // Update is called once per frame
        void Update () {
	
        }

        void setTiles()
        {
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    //(gridOrigin.x + 2*x),(gridOrigin.y + 2*y)
                    Layout[x,y] =  gameObject.AddComponent<Tile>();
                    Layout[x,y].TileIndex = new Vector2(x,y);
                    Layout[x, y].TilePos = new Vector3((gridOrigin.x + 20*x),0,(gridOrigin.z - 20*y));
                }
            }
        }

        public List<Tile> getNeighbors(Tile tile)
        {
            //TODO Write code that finds neighbor of tile passed in.
            
            return neighbors;
        }
    }
}
