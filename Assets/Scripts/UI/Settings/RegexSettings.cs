using TMPro;
using UnityEngine;

public class RegexSettings : MonoBehaviour
{
    [SerializeField] private TMP_Text defaultTxt;
    private Color grayColor = Color.gray;
    private Color whiteColor = Color.white;
    [SerializeField] private CheckBox defCheckBox;
    [SerializeField] private TMP_InputField inputField;

    private void Awake()
    {
        defCheckBox.CheckBoxEvent.AddListener(defaultCheck);
        inputField.onValueChanged.AddListener(inputChanged);

        bool check = PlayerPrefs.GetInt("RegexDefault") == 0 ? true : false;

        defCheckBox.Setup(check);
        defaultCheck(check);

        if (PlayerPrefs.HasKey("Regex"))
            inputField.text = PlayerPrefs.GetString("Regex");
        else
        {
            string regex = ":|;\\r?\\n?";
            inputField.text = regex;
            PlayerPrefs.SetString("Regex", regex);
        }
    }

    private void inputChanged(string str)
    {
        PlayerPrefs.SetString("Regex", str);
    }

    private void defaultCheck(bool value)
    {
        PlayerPrefs.SetInt("RegexDefault", value == true ? 0 : 1);

        defaultTxt.color = value ? whiteColor : grayColor;

        inputField.interactable = !value;
    }
}
