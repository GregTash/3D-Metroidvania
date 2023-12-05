using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;

public class OnHoverUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 origSize = new Vector3();
    [SerializeField] private Vector3 newSize = new Vector3();
    [SerializeField] private float speed;

    private void Start()
    {
        origSize = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.DOScale(newSize, speed);
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        transform.DOScale(origSize, speed);
    }
}
