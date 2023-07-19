using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class LinkOpener : MonoBehaviour, IPointerDownHandler
{
    private TMP_Text text;
    private new Camera camera;

    private void Awake()
    {
        camera = Camera.main;
        text = gameObject.GetComponent<TMP_Text>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink
            (text, Input.mousePosition, camera);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];

            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}
