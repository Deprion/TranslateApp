using System.IO;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private GameObject editFile;

    private void Awake()
    {
        Events.OpenFile.AddListener(OpenFile);
    }

    private void OpenFile(string str)
    {
        var obj = Instantiate(editFile, transform, false);
        string name = PlayerPrefs.GetString("Path") + "\\" + str;
        obj.GetComponent<EditorFile>().Init(str, File.ReadAllText(name));
    }
}
