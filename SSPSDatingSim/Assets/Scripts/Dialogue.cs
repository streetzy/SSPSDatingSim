using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class Dialogue : MonoBehaviour
{

    [SerializeField] private GameObject dialogueTexts;
    [SerializeField] private GameObject narratorTexts;

    private List<GameObject> narratorTextList = new();
    private List<GameObject> dialogueTextList = new();


    private void GetChildren()
    {
        foreach (Transform child in narratorTexts.transform)
        {
            var componentText = child.gameObject.GetComponent<TextMeshProUGUI>().text;
            if (componentText == "{PlayerName}")
            {
                child.gameObject.GetComponent<TextMeshProUGUI>().text = MenuNav.PlayerName;
            }
            dialogueTextList.Add(child.gameObject);
        }
        foreach (Transform child in dialogueTexts.transform)
        {
            var componentText = child.gameObject.GetComponent<TextMeshProUGUI>().text;
            if (componentText.Contains("{PlayerName}"))
            {
                child.gameObject.GetComponent<TextMeshProUGUI>().text = componentText.Replace("{PlayerName}", MenuNav.PlayerName);
                
            }
            narratorTextList.Add(child.gameObject);
        }
    }
    private void Start()
    {
        GetChildren();

        if (MenuNav.loadedFlag)
        {
            narratorTextList[0].SetActive(false);
            dialogueTextList[0].SetActive(false);
            
            narratorTextList[MenuNav.CurrentIndex].SetActive(true);
            dialogueTextList[MenuNav.CurrentIndex].SetActive(true);
            MenuNav.loadedFlag = false;
        }
    }

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


        if (MenuNav.CurrentIndex == narratorTextList.Count - 1)
        {
            narratorTextList[MenuNav.CurrentIndex].SetActive(false);
            dialogueTextList[MenuNav.CurrentIndex].SetActive(false);
            
            narratorTextList[0].SetActive(true);
            dialogueTextList[0].SetActive(true);

            
            narratorTextList.Clear();
            dialogueTextList.Clear();

            MenuNav.SceneChange();
            GetChildren();
            return;
        }

        narratorTextList[MenuNav.CurrentIndex].SetActive(false);
        dialogueTextList[MenuNav.CurrentIndex].SetActive(false);
        
        MenuNav.CurrentIndex++;
        
        narratorTextList[MenuNav.CurrentIndex].SetActive(true);
        dialogueTextList[MenuNav.CurrentIndex].SetActive(true);

    }
}
