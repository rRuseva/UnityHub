//using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    //public SceneAsset mainMenuScene = null;
    //public SceneAsset endlessRunnerScene = null;

    public void LoadGame() {
        //SceneManager.LoadScene(endlessRunnerScene.name);
        SceneManager.LoadScene("EndlessRunnerScene");
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene("MainMenuScene");
    }

    public void EndGame() {
        Application.Quit();
    }
}
