using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class NewRoom : MonoBehaviour {
        private Grid floorLayout;
        public Grid FloorLayout { get { return floorLayout; } }
        public int movesAllowed;
        public int startX;
        public int startY;
        public bool isCurrentRoom;

        private AudioSource LaserNoise;
        private bool startPlaying;
        private bool isPlaying;

        private Tile startingTile;
        public Tile StartingTile { get { return startingTile; } set { startingTile = value; } }

        void Awake()
        {
            LaserNoise = GetComponent<AudioSource>();
            startPlaying = false;
            isPlaying = false;
        }
        // Use this for initialization
        void Start ()
        {
            floorLayout = gameObject.GetComponentInChildren<Grid>();
            startingTile = floorLayout.FloorTiles[startX, startY];
        }
	
        // Update is called once per frame
        void Update () {
            if (LaserNoise != null)
            {
                startPlaying = checkSound();
            }

            if(startPlaying)
            {
                if(!(isPlaying))
                {
                    isPlaying = true;
                    LaserNoise.Play();
                }
            }
            else
            {
                LaserNoise.Stop();
            }
            startingTile = floorLayout.FloorTiles[startX, startY];
        }

        private bool checkSound()
        {
            if(isCurrentRoom)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
