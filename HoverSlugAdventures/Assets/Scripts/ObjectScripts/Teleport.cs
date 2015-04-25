using UnityEngine;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class Teleport : MonoBehaviour
    {
        private ParticleSystem burst;
        void Start()
        {
            burst = gameObject.GetComponentInChildren<ParticleSystem>();
        }
        void OnTriggerEnter()
        {
            burst.Play();
        }
    }
}