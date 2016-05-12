using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public Material[] materials;
    private bool switchToggle;
    private Renderer rend;
    private AudioSource sound;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        sound = GetComponent<AudioSource>();
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
			AkSoundEngine.PostEvent ("Play_SwitchOn", gameObject);
        }
        else
        {
            rend.sharedMaterial = materials[0];
			AkSoundEngine.PostEvent ("Play_SwitchOff", gameObject);
        }
        //sound.Play();
    }

    public void Reset()
    {
        switchToggle = false;
        rend.sharedMaterial = materials[0];
    }
}
