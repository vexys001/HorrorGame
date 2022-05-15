using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    GameObject _pausePanel;

    private void Awake()
    {
        _pausePanel.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            _pausePanel.SetActive(true);
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartMenu()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
