using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class RoomTrigger : MonoBehaviour
    {
        public Player player;
        public NewRoom nextRoom;
        private Camera mainCamera;
        private const float cameraSpeed = 18;
        private float startTime;
        private float cameraDistance;
        private float distCovered;
        private float fracJourney;
        private bool triggered;
        public Transform previousCameraLocation;
        public Transform nextCameraLocation;

        // Use this for initialization
        void Start ()
        {
            cameraDistance = Vector3.Distance(previousCameraLocation.transform.position,
                nextCameraLocation.position);
            mainCamera = gameObject.GetComponentInParent<Camera>();
            transform.parent = null;
        }
	
        // Update is called once per frame
        void Update () {

            if (triggered)
            {
                distCovered = (Time.time - startTime)*cameraSpeed;
                fracJourney = distCovered/cameraDistance;
                mainCamera.transform.position = Vector3.Lerp(previousCameraLocation.position,
                    nextCameraLocation.position, fracJourney);
                if (mainCamera.transform.position == nextCameraLocation.transform.position)
                {
                    triggered = false;
                }
            }
        }

        void OnTriggerEnter(Collider otherCollider)
        {
            if (player.CurrentRoom != nextRoom)
            {
                triggered = true;
                startTime = Time.time;
                player.switchRoom(nextRoom);
                player.AddMoves(nextRoom.movesAllowed);
            }
        }

        public void MenuPress()
        {
            triggered = true;
            startTime = Time.time;
        }
    }
}
