using UnityEngine;

public class PopupManager : MonoBehaviour
{
    [SerializeField] private GameObject popup;
    [SerializeField] private Transform parent;
    public static PopupManager inst;

    private GameObject popUpCur;

    private void Awake()
    {
        inst = this;
    }

    public void CreatePopup(ItemList item)
    {
        if (popUpCur != null) Destroy(popUpCur);

        popUpCur = Instantiate(popup, parent, false);

        popUpCur.transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var it = popUpCur.GetComponent<Popup>();

        it.AddItem("Rename", item.Rename);
        it.AddItem("Delete", item.Delete);
    }
}
