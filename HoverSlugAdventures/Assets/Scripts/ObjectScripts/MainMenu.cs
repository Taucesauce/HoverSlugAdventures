using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour {

    //Dependencies
    private Text titleText;
    private Button StartButton;
    private Button ExitGame;
    public Canvas HUD;
    public Canvas Room1Controls;


	// Use this for initialization
	void Awake () {
        titleText = gameObject.GetComponentInChildren<Text>();
        StartButton = gameObject.GetComponentInChildren<Button>();
        ExitGame = StartButton.GetComponentInChildren<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(StartButton.gameObject.activeSelf == false)
        {
            this.gameObject.SetActive(false);
            HUD.gameObject.SetActive(true);
            Room1Controls.gameObject.SetActive(true);
        }
	}
}
