using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class GameManager : MonoBehaviour
{
    public const int START_MENU_SCENE_INDEX = 0;
    public const int GAME_SCENE_INDEX = 1;
    public const int GAME_OVER_SCENE_INDEX = 2;

    public void LoadGame()
    {
        string gameScene = SceneUtility.GetScenePathByBuildIndex(GAME_SCENE_INDEX);
        SceneManager.LoadScene(gameScene);
    }


    public void OnEnable()
    {
        OnPlayerDead.OnPlayerDeadEvent += LoadGameOverScene;
    }

    public void LoadGameOverScene()
    {
        string gameOverScene = SceneUtility.GetScenePathByBuildIndex(GAME_OVER_SCENE_INDEX);
        SceneManager.LoadScene(gameOverScene);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void OnDisable()
    {
        OnPlayerDead.OnPlayerDeadEvent -= LoadGameOverScene;
    }

}
