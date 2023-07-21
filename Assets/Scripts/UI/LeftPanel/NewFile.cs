using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewFile : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!PlayerPrefs.HasKey("Path")) return;

        File.Create(PlayerPrefs.GetString("Path") + "\\" + Random.Range(0.0f, 100.0f) + ".txt");

        Events.RefreshFileList.Invoke();
    }
}
