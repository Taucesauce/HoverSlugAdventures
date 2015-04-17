using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class Tile : MonoBehaviour {

        public enum TileType { Empty, Wall, Fast, Slow }

        private Vector3 tilePos;
        public Vector3 TilePos { get { return tilePos; } set { tilePos = value; } }
        private Vector3 tileCenter;
        private Vector2 tileIndex;
        public Vector2 TileIndex { get { return tileIndex; } set { tileIndex = value; } }

        public Vector3 TileCenter { get { return tileCenter; } }
        private TileType currentType;
        private const int tileWidth = 2;
        private const int tileHeight = 2;

        // Use this for initialization
        void Start() 
        {
            tileCenter = new Vector3(tilePos.x + 10, tilePos.y + 10, tilePos.z - 10);
        }
	    

        // Update is called once per frame
        void Update () {
	
        }

        void setType(TileType type)
        {
            currentType = type;
        }
    }
}
