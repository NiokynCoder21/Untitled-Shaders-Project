using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Transitions : MonoBehaviour
{
    public void onStartGame(InputAction.CallbackContext context)
    {
        StartGame();
    }

    public void onQuitGame(InputAction.CallbackContext context)
    {
        QuitGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Scence", LoadSceneMode.Single); //load the sameple scence basicallys restarts the level
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
