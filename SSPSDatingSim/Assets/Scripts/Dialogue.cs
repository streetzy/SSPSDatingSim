using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.IO;
using TMPro;

public class Dialogue : MonoBehaviour
{

    static void ReadString()
    {
        string path = Application.streamingAssetsPath + "texts.txt";
        using (StreamReader sr = new StreamReader(path))
        {
            while (true)
            {
                string? line = sr.ReadLine();
                if (line != null)
                {
                    line.Split(": ");
                    string narrator = line[0].ToString();
                    string dialogueText = line[1].ToString();
                    dialogue.Add((narrator, dialogueText));
                }
                else
                {
                    break;
                }
            }
        }
    }
    
    public static List<(string narrator, string text)> dialogue = new();
    
    private readonly DialogueChange m_DialogueChange = new DialogueChange();
    
    private void OnEnable()
    {
        EventManager.ButtonClicked += EventManagerOnButtonClicked;
    }

    private void OnDisable()
    {
        EventManager.ButtonClicked -= EventManagerOnButtonClicked;
    }

    private void EventManagerOnButtonClicked()
    {
        m_DialogueChange.Execute();
    }
    
    [SerializeField]
    TextMeshProUGUI dialogueText;

    [SerializeField]
    TextMeshProUGUI narratorName;
}
