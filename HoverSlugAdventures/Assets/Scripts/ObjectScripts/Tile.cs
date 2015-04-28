using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class Tile : MonoBehaviour {

        public enum TileType { Open, Closed, RoomFinish, Teleport, Switch }

        private Vector3 tilePos;
        public Vector3 TilePos { get { return tilePos; } set { tilePos = value; } }
        private Vector2 tileIndex;
        public Vector2 TileIndex { get { return tileIndex; } set { tileIndex = value; } }
        //HACKED AS FUCK
        public Tile teleportDestination;
        public TileType currentType;

        // Use this for initialization
        void Start() 
        {
            
        }

        public void AddTexture(Texture texture)
        {
            this.GetComponent<MeshRenderer>().material.mainTexture = texture;
        }
	    

        // Update is called once per frame
        void Update () {
	
        }
    }
}
