using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNav : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI incorrectFormat;
    [SerializeField] Image enterPlayerName;
    [SerializeField] TMP_InputField input;
    public static string PlayerName;
    public static int CurrentIndex;

    public static void SceneChange()
    {
        CurrentIndex = 0;
        
        EventSystem.current.gameObject.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            SceneManager.LoadScene(0);
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    private void SubmitName(string inputName)
    {
        if (!(inputName.Length > 8))
        {
            PlayerName = inputName;
            SceneChange();
            return;
        }

        incorrectFormat.gameObject.SetActive(true);

    }
    
    private void Awake()
    {
        enterPlayerName.gameObject.SetActive(false);
        incorrectFormat.gameObject.SetActive(false);
        
        input.onEndEdit.AddListener(SubmitName);
    }

    public void BeginNewGame()
    {
        enterPlayerName.gameObject.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
