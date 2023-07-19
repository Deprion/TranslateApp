using System.Collections;
using UnityEngine;

public class SettingsBtnAnim : MonoBehaviour
{
    [SerializeField] private GameObject fullCircle;
    [SerializeField] private float animSpeed;
    private float progress = 0;

    public IEnumerator ShowCircle(bool val)
    {
        if (val)
        {
            while (fullCircle.transform.localScale != Vector3.one)
            {
                fullCircle.transform.localScale = Vector3.Lerp
                    (Vector3.zero, Vector3.one, progress);
                yield return new WaitForEndOfFrame();

                progress += Time.deltaTime * animSpeed;
            }
        }
        else
        {
            while (fullCircle.transform.localScale != Vector3.zero)
            {
                fullCircle.transform.localScale = Vector3.Lerp
                    (Vector3.one, Vector3.zero, progress);
                yield return new WaitForEndOfFrame();

                progress += Time.deltaTime * animSpeed;
            }
        }

        progress = 0;
    }
}