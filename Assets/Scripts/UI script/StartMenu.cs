using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    [SerializeField]
    private Animator _imageTransition;
    [SerializeField]
    private float _transTime = 1f;

    public void LoadScene()
    {
        StartCoroutine(LoadLevel("Day01"));
    }

    IEnumerator LoadLevel(string levelName)
    {
        _imageTransition.SetTrigger("start");
        yield return new WaitForSeconds(_transTime);
        SceneManager.LoadScene(levelName);
    }

    public void QuitScene()
    {
        Application.Quit();
    }
}
