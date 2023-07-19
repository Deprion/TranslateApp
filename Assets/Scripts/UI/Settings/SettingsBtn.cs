using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsBtn : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private SettingsPanelAnim panelAnim;
    private SettingsBtnAnim btnAnim;
    private bool isShow = false;

    private void Awake()
    {
        btnAnim = GetComponent<SettingsBtnAnim>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        StopAllCoroutines();
        panelAnim.StopAllCoroutines();

        isShow = !isShow;

        StartCoroutine(btnAnim.ShowCircle(isShow));
        StartCoroutine(panelAnim.Show(isShow));
    }
}
