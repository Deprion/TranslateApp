using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private GameObject editFile;

    private List<EditorFile> files = new List<EditorFile>();

    private void Awake()
    {
        Events.OpenFile.AddListener(OpenFile);

        Events.Save.AddListener(Save);
    }

    private void Save()
    { 
        foreach (var file in files) 
        {
            file.Save();
        }
    }

    private void OpenFile(string str)
    {
        var obj = Instantiate(editFile, transform, false);
        string name = PlayerPrefs.GetString("Path") + "\\" + str;
        obj.GetComponent<EditorFile>().Init(str, File.ReadAllText(name));

        files.Add(obj.GetComponent<EditorFile>());
    }
}
