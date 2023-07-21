using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Explorer : MonoBehaviour
{
    [SerializeField] private Button selectBtn, cancelBtn, upBtn;
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private GameObject item;
    [SerializeField] private GameObject content;

    private void Awake()
    {
        cancelBtn.onClick.AddListener(() => Destroy(gameObject));
        selectBtn.onClick.AddListener(Select);
        upBtn.onClick.AddListener(() => FolderUp(inputField.text));
        inputField.onEndEdit.AddListener(ChangeDir);

        Init();
    }

    private void FolderUp(string path)
    {
        if (!path.Contains("\\")) return;

        path = path[..path.LastIndexOf("\\")];

        if (!path.Contains("\\"))
        {
            path += "\\";
        }

        ChangeDir(path);
    }

    private void Init()
    {
        string path;
        if (PlayerPrefs.HasKey("Path"))
            path = PlayerPrefs.GetString("Path");
        else
        {
            path = Application.dataPath.Replace("/", "\\");
        }

        ShowDir(path);
    }

    private void ShowDir(string path)
    {
        if (!Directory.Exists(path)) return;

        for (int i = content.transform.childCount - 1; i >= 0; i--)
        {
            Destroy(content.transform.GetChild(i).gameObject);
        }

        inputField.text = path;

        var list = Directory.GetDirectories(path);

        foreach (var l in list)
        {
            var obj = Instantiate(item, content.transform, false);
            obj.GetComponent<Item>().Init(this, l);
        }
    }

    private void Select()
    {
        Events.SetPath.Invoke(inputField.text);

        Destroy(gameObject);
    }

    public void ChangeDir(string path)
    {
        ShowDir(path);
    }
}
