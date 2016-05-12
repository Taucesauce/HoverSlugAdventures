using UnityEngine;
using System.Collections;

public class EndMenu : MonoBehaviour {

    public void RestartGame()
    {
		AkSoundEngine.PostEvent ("Play_StartButton", gameObject);
        Application.LoadLevel("Level1");
		//AkSoundEngine.PostEvent ("Stop_Music", gameObject);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
