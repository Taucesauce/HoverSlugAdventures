using UnityEngine;
using System.Collections;

public class EndMenu : MonoBehaviour {

    public void RestartGame()
    {
        Application.LoadLevel("Level1");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
