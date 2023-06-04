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
    private readonly SceneChange m_SceneChange = new SceneChange();
    
    private void SubmitName(string inputName)
    {
        if (!(inputName.Length > 8))
        {
            PlayerName = inputName;
            Debug.Log(PlayerName);
            m_SceneChange.Execute();
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
