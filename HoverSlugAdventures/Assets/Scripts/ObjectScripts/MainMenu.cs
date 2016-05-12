using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //Dependencies
    private Button StartButton;
    public Canvas HUD;

	// Use this for initialization
	void Awake () {
        StartButton = gameObject.GetComponentInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(StartButton.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);
			AkSoundEngine.PostEvent ("Play_StartButton", gameObject);
        }
	}
}
