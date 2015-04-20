using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class NewRoom : MonoBehaviour {
        private Grid floorLayout;
        public Grid FloorLayout { get { return floorLayout; } }
        public int movesAllowed;
        public int startX;
        public int startY;

        private Tile startingTile;
        public Tile StartingTile { get { return startingTile; } set { startingTile = value; } }

        void Awake()
        {
            
        }
        // Use this for initialization
        void Start ()
        {
            floorLayout = gameObject.GetComponentInChildren<Grid>();
            startingTile = floorLayout.FloorTiles[startX, startY];
        }
	
        // Update is called once per frame
        void Update () {
	
        }
    }
}
