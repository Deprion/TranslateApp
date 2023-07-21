using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    private bool autoSave;

    private void Awake()
    {
        Events.isAutoSave.AddListener((bool val) => autoSave = val, true);
    }

    private void OnApplicationQuit()
    {
        if (autoSave)
            Events.Save.Invoke();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (autoSave && !focus)
            Events.Save.Invoke();
    }
}
