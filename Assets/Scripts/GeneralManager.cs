using UnityEngine;

public class GeneralManager : MonoBehaviour
{
    private bool autoSave;

    private void Awake()
    {
        Events.isAutoSave.AddListener((bool val) => autoSave = val, true);
        Events.SetPath.AddListener(UpdatePath);
    }

    private void UpdatePath(string path)
    {
        PlayerPrefs.SetString("Path", path);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.S))
        {
            Events.Save.Invoke();
        }
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
