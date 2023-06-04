using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public interface IInst
{
    public void Execute();
}

public class SceneChange : IInst
{
    public void Execute()
    {
        EventSystem.current.gameObject.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
}

public class DialogueChange : IInst
{
    private void EventManagerOnDialogueChange()
    {
        Execute();
    }
    
    public void Execute()
    {
        
        
        string nextNarrator;
        
        string nextText;

        TextMeshPro dialogueText;
        TextMeshPro narratorText;

    }
}
public class Instructions : MonoBehaviour {
    List<IInst> m_Commands = new List<IInst>();
}


