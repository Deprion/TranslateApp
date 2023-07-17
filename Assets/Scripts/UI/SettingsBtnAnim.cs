using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SettingsBtnAnim : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private GameObject fullCircle;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (fullCircle.transform.localScale.x <= 0)
            StartCoroutine(ShowCircle(true));
        else
            StartCoroutine(ShowCircle(false));
    }

    private IEnumerator ShowCircle(bool val)
    {
        int dir = val == true ? 1 : -1;

        while (true)
        {
            fullCircle.transform.localScale = fullCircle.transform.localScale + new Vector3(0.1f * dir, 0.1f * dir, 0);
            yield return new WaitForSeconds(0.05f);

            if (val == true && fullCircle.transform.localScale.x >= 1) break;
            if (val == false && fullCircle.transform.localScale.x <= 0) break;
        }
    }
}