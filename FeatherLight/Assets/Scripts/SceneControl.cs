using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneControl : MonoBehaviour
{
    // Function to restart the current scene
    public void RestartScene()
    {
        // Get the current scene name and reload it
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    // Function to load the next scene in the build settings
    public void LoadNextLevel()
    {
        // Get the current scene index and load the next one
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
