using System.IO;
using TMPro;
using UnityEngine;

public class EditorFile : MonoBehaviour
{
    [SerializeField] private TMP_Text labelTxt;
    [SerializeField] private TMP_InputField contentTxt;

    public void Init(string label, string content)
    {
        labelTxt.text = label;
        contentTxt.text = content;
    }

    public void Save()
    {
        File.WriteAllText(PlayerPrefs.GetString("Path") + "\\" + labelTxt.text, 
            contentTxt.text);
    }
}
