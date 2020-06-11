using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public SceneAsset mainMenuScene;
    public SceneAsset endlessRunnerScene;

    public void LoadGame() {
        SceneManager.LoadScene(endlessRunnerScene.name);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(mainMenuScene.name);
    }

    public void EndGame() {
        Application.Quit();
    }
}
