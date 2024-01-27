using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDropFace : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector2 imagePosition;
    
    private RectTransform _rectTransform;
    
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var pointerData = eventData as PointerEventData;
        var image = eventData.pointerDrag.GetComponent<Image>();
        image.raycastTarget = false;
        transform.SetAsLastSibling();
        imagePosition = image.transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var image = eventData.pointerDrag.GetComponent<Image>();
        image.raycastTarget = true;
    }
}
