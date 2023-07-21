using System.IO;
using UnityEngine;

public class FileList : MonoBehaviour
{
    [SerializeField] private GameObject item;
    [SerializeField] private Transform parent;

    private void Awake()
    {
        Events.SetPath.AddListener(UpdateList);
        Events.RefreshFileList.AddListener(Refresh);

        Refresh();
    }

    private void Refresh()
    {
        if (PlayerPrefs.HasKey("Path"))
            UpdateList(PlayerPrefs.GetString("Path"));
    }

    private void UpdateList(string path)
    {
        for (int i = parent.childCount - 1; i >= 0; i--)
        {
            Destroy(parent.GetChild(i).gameObject);
        }

        foreach (var obj in Directory.GetFiles(path, "*.txt"))
        {
            var temp = Instantiate(item, parent, false);
            temp.GetComponent<ItemList>().Init(obj);
        }
    }
}
