using UnityEngine;

namespace Assets.Scripts.ObjectScripts
{
    public class ObjectManipulation : MonoBehaviour
    {
        private InteractiveObject objectToManipulate;
        private bool isObjectActive;
        private bool startingState;
        void Start()
        {
            objectToManipulate = GetComponentInChildren<InteractiveObject>();
            objectToManipulate.gameObject.SetActive(objectToManipulate.StartingState);
        }
        void Update()
        {
            isObjectActive = objectToManipulate.gameObject.activeSelf;
        }
        void OnTriggerEnter()
        {
            objectToManipulate.gameObject.SetActive(!isObjectActive);
        }

        public void Reset()
        {
            objectToManipulate.gameObject.SetActive(objectToManipulate.StartingState);
        }


    }
}
