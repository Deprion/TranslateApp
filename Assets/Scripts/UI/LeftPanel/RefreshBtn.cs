using UnityEngine;
using UnityEngine.EventSystems;

public class RefreshBtn : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        Events.RefreshFileList.Invoke();
    }
}
