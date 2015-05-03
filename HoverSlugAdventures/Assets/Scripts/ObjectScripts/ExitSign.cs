using UnityEngine;
using System.Collections;
using Assets.Scripts.ObjectScripts;

namespace Assets.Scripts.ObjectScripts
{
    public class ExitSign : MonoBehaviour
    {
        private NewRoom currentRoom;
        public GameObject sign;

        // Use this for initialization
        private void Start()
        {
            currentRoom = gameObject.GetComponentInParent<NewRoom>();
            
        }

        // Update is called once per frame
        private void Update()
        {
            if (currentRoom.FloorLayout.SwitchNum <= 0)
            {
                sign.SetActive(true);
            }
            else
            { 
                sign.SetActive(false);
            }
        }
    }
}