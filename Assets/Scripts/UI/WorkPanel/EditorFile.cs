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

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.RightShift))
        {
            contentTxt.text = contentTxt.text.Insert(contentTxt.caretPosition, "\n");
        }
    }

    public void Save()
    {
        File.WriteAllText(PlayerPrefs.GetString("Path") + "\\" + labelTxt.text, 
            contentTxt.text);
    }
}
