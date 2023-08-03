using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RaisePlatform : MonoBehaviour
{
    [SerializeField] GameObject platform;
    public void RaisePlatformObject()
    {
        platform.transform.DOMoveY(-8.2f, 1f);
    }
}
