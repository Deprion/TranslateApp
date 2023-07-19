using System.Collections;
using UnityEngine;

public class SettingsPanelAnim : MonoBehaviour
{
    [SerializeField] private RectTransform panel;
    [SerializeField] private float animSpeed;
    private float progress = 0;

    private Vector3 left = new Vector3(-200, 0, 0);
    private Vector3 right = new Vector3(200, 0, 0);

    private void Awake()
    {
        panel = GetComponent<RectTransform>();
    }

    public IEnumerator Show(bool val)
    {
        if (val)
        {
            while (panel.anchoredPosition.x < 200)
            {
                panel.anchoredPosition = Vector3.Lerp
                    (left, right, progress);
                yield return new WaitForEndOfFrame();

                progress += Time.deltaTime * animSpeed;
            }
        }
        else
        {
            while (panel.anchoredPosition.x > -200)
            {
                panel.anchoredPosition = Vector3.Lerp
                    (right, left, progress);
                yield return new WaitForEndOfFrame();

                progress += Time.deltaTime * animSpeed;
            }
        }

        progress = 0;
    }
}
