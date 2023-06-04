using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour
{
    [SerializeField] private GameObject escScreen;
    public static int buildIndexOfLastScene;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (escScreen.activeSelf)
            {
                escScreen.SetActive(false);
                return;
            }
            escScreen.SetActive(true);
        }
    }

    public void Resume()
    {
        escScreen.SetActive(false);
    }

    public void Exit()
    {
        escScreen.SetActive(false);
        buildIndexOfLastScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(0);
    }

}
