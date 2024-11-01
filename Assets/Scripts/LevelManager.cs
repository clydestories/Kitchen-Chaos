using UnityEngine.SceneManagement;

public static class LevelManager
{
    public static void LoadLevel(LevelName levelName)
    {
        SceneManager.LoadScene(levelName.ToString());
    }
}

public enum LevelName
{
    MainMenu,
    Game
}