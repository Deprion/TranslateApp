using System.IO;
using UnityEngine;

public class WorkManager : MonoBehaviour
{
    [SerializeField] private GameObject editFile;

    private EditorFile file;

    public void CloseFile()
    {
        Save();

        if (file != null) Destroy(file.gameObject);
    }

    private void Awake()
    {
        Events.OpenFile.AddListener(OpenFile);

        Events.Save.AddListener(Save);
    }

    private void Save()
    {
        if (file != null) file.Save();
    }

    private void OpenFile(string str)
    {
        Save();

        if (file != null) Destroy(file.gameObject);

        var obj = Instantiate(editFile, transform, false);
        string name = PlayerPrefs.GetString("Path") + "\\" + str;

        file = obj.GetComponent<EditorFile>();
        file.Init(str, File.ReadAllText(name));
    }
}
