using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindSaveInstance : MonoBehaviour
{
    private Button thisButton;
    private Save saveInstance;
    
    void Start()
    {
        saveInstance = GameObject.FindWithTag("saveTag").GetComponent<Save>();

        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(saveInstance.SaveToFile);
    }

}
