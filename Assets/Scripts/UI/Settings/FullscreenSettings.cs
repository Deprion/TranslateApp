using TMPro;
using UnityEngine;

public class FullscreenSettings : MonoBehaviour
{
    [SerializeField] private TMP_Text fullTxt;
    [SerializeField] private CheckBox fullCheckBox;
    private Color grayColor = Color.gray;
    private Color whiteColor = Color.white;

    private void Awake()
    {
        fullCheckBox.CheckBoxEvent.AddListener(FullscreenCheck);

        bool full = PlayerPrefs.GetInt("Fullscreen") == 0 ? false : true;
        FullscreenCheck(full);
        fullCheckBox.Setup(full);
    }

    private void FullscreenCheck(bool value)
    {
        PlayerPrefs.SetInt("Fullscreen", value == true ? 1 : 0);

        fullTxt.color = value ? whiteColor : grayColor;

        if (value)
        {
            Screen.SetResolution(Screen.mainWindowDisplayInfo.width, 
                Screen.mainWindowDisplayInfo.height, true);
        }
        else
        {
            Screen.SetResolution(1280, 720, false);
        }
    }
}
