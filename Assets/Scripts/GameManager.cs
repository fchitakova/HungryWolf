using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public SceneAsset startGameScene;
    public SceneAsset gameScene;
    public SceneAsset gameOverScene;

    public void LoadGame()
    {
        SceneManager.LoadScene(gameScene.name);
    }


    public void OnEnable()
    {
        PlayerHealth.OnPlayerDead += LoadGameOverScene;
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene(gameOverScene.name);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void OnDisable()
    {
        PlayerHealth.OnPlayerDead -= LoadGameOverScene;
    }


}
