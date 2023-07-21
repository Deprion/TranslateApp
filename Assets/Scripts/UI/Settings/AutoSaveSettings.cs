using TMPro;
using UnityEngine;

public class AutoSaveSettings : MonoBehaviour
{
    [SerializeField] private TMP_Text Txt;
    [SerializeField] private CheckBox CheckBox;
    private Color grayColor = Color.gray;
    private Color whiteColor = Color.white;

    private void Awake()
    {
        CheckBox.CheckBoxEvent.AddListener(AutoSaveCheck);

        bool val = PlayerPrefs.GetInt("AutoSave") == 0 ? false : true;
        AutoSaveCheck(val);
        CheckBox.Setup(val);
    }

    private void AutoSaveCheck(bool value)
    {
        PlayerPrefs.SetInt("AutoSave", value == true ? 1 : 0);

        Events.isAutoSave.Invoke(value);

        Txt.color = value ? whiteColor : grayColor;
    }
}
