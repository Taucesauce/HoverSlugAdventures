using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public Material[] materials;
    private bool switchToggle;
    private Renderer rend;
	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        switchToggle = false;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    void OnTriggerEnter()
    {
        switchToggle = !switchToggle;
        if(switchToggle)
        {
            rend.sharedMaterial = materials[1];
        }
        else
        {
            rend.sharedMaterial = materials[0];
        }
    }

    public void Reset()
    {
        switchToggle = false;
        rend.sharedMaterial = materials[0];
    }
}
