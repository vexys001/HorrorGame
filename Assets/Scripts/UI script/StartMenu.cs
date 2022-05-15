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
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }

    IEnumerator LoadLevel(int level)
    {
        level = 3;
        _imageTransition.SetTrigger("start");
        yield return new WaitForSeconds(_transTime);
        SceneManager.LoadScene(level);
    }

    public void QuitScene()
    {
        Application.Quit();
    }
}
