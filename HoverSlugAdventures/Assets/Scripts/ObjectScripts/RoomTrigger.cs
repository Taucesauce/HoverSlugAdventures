using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class RoomTrigger : MonoBehaviour
    {
        public Player player;
        public Room nextRoom;
        public Camera camera;
        private float cameraSpeed = 30;
        private float startTime;
        private float cameraDistance;
        private bool triggered;
        public Transform previousCameraLocation;
        public Transform nextCameraLocation;

        // Use this for initialization
        void Start ()
        {
            cameraDistance = Vector3.Distance(previousCameraLocation.position,
                nextCameraLocation.position);
        }
	
        // Update is called once per frame
        void Update () {

            if (triggered)
            {
                float distCovered = (Time.time - startTime)*cameraSpeed;
                float fracJourney = distCovered/cameraDistance;
                camera.transform.position = Vector3.Lerp(previousCameraLocation.position,
                    nextCameraLocation.position, fracJourney);
            }
        }

        void OnTriggerEnter(Collider playerCollider)
        {
            triggered = true;
            startTime = Time.time;
            if (player.CurrentRoom != nextRoom)
            {
                player.switchRoom(nextRoom);
                player.AddMoves(nextRoom.movesAllowed);
            }
        }
    }
}
