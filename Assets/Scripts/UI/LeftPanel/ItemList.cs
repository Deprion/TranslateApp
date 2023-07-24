using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemList : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_InputField inputField;

    public void Init(string name)
    {
        var arr = name.Split('\\');
        text.text = arr[arr.Length - 1];
    }

    public void Rename()
    {
        inputField.text = text.text;

        inputField.gameObject.SetActive(true);
        text.gameObject.SetActive(false);

        inputField.Select();

        inputField.onEndEdit.AddListener(EndEdit);
    }

    private void EndEdit(string str)
    {
        File.Move(PlayerPrefs.GetString("Path") + "\\" + text.text,
            PlayerPrefs.GetString("Path") + "\\" + str);

        text.text = str;

        text.gameObject.SetActive(true);
        inputField.gameObject.SetActive(false);

        inputField.onEndEdit.RemoveListener(EndEdit);
    }

    public void Delete()
    { 
        File.Delete(PlayerPrefs.GetString("Path") + "\\" + text.text);

        Events.RefreshFileList.Invoke();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            PopupManager.inst.CreatePopup(this);
        }
        else
        {
            Events.OpenFile.Invoke(text.text);
        }
    }
}
