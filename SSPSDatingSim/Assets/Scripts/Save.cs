using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Save : MonoBehaviour
{
    public string saveFileName = "SaveFile";
    private string m_Path;

    private static Save _instance;

    public static SaveTemplate SaveTemplate;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);

        m_Path = Application.persistentDataPath + "/" + saveFileName + ".json";

        if (!File.Exists(m_Path))
        {
            SaveTemplate defaultSaveTemplate = new SaveTemplate
            {
                currentSceneBuildIndex = EscapeMenu.buildIndexOfLastScene,
                currentDialogueIndex = MenuNav.CurrentIndex,
                playerName = MenuNav.PlayerName
            };

            string defaultJson = JsonUtility.ToJson(defaultSaveTemplate);
            File.WriteAllText(m_Path, defaultJson);
            SaveTemplate = defaultSaveTemplate;
        }
        else
        {
            string saveJson = File.ReadAllText(m_Path);
            SaveTemplate = JsonUtility.FromJson<SaveTemplate>(saveJson);
        }
    }
}

[System.Serializable]
public class SaveTemplate
{
    public int currentSceneBuildIndex;
    public int currentDialogueIndex;
    public string playerName;
}
