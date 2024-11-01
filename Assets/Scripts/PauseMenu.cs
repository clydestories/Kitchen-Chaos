using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void ExitToMainMenu()
    {
        LevelManager.LoadLevel(LevelName.MainMenu);
    }
}
