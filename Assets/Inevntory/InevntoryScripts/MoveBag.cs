using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveBag : MonoBehaviour, IDragHandler
{
    public Canvas canvas;
    RectTransform currentRect;

    public void OnDrag(PointerEventData eventData)
    {
        currentRect.anchoredPosition += eventData.delta;
    }

    void Awake()
    {
        currentRect = GetComponent<RectTransform>();
    }
}
