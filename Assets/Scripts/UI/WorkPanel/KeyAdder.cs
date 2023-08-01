using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyAdder : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private Button btn;
    [SerializeField] private WorkManager workM;

    private void Awake()
    {
        btn.onClick.AddListener(AddKey);
    }

    private void AddKey()
    {
        if (!PlayerPrefs.HasKey("Path")) return;

        workM.CloseFile();

        string key = input.text + ":;\n";

        foreach (var obj in Directory.GetFiles(PlayerPrefs.GetString("Path"), "*.txt"))
        {
            File.AppendAllText(obj, key);
        }

        input.text = string.Empty;
    }
}
