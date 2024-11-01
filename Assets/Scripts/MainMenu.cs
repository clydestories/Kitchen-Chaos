using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void Play()
    {
        LevelManager.LoadLevel(LevelName.Game);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
