using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class Room : MonoBehaviour
    {
        public Grid floorLayout;
        public int movesAllowed;
        public int startX;
        public int startY;

        private Tile startingTile;
        public Tile StartingTile { get { return startingTile; } set { startingTile = value; } }
    
        // Use this for initialization
        private void Awake()
        {
            floorLayout = gameObject.GetComponentInChildren<Grid>();
            startingTile = gameObject.AddComponent<Tile>();
            startingTile = floorLayout.FloorTiles[startX, startY];
        }
	
        // Update is called once per frame
        void Update () 
        {
        }
    }
}
