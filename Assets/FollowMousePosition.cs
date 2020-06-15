using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    [SerializeField] RectTransform _rectTransform;

    void LateUpdate()
    {
        _rectTransform.position = Input.mousePosition;
    }
}
