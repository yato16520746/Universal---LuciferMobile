using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMousePosition : MonoBehaviour
{
    [SerializeField] RectTransform _rectTransform;

    private void Start()
    {
#if UNITY_EDITOR
#else
        Cursor.visible = false;
#endif
    }

    void LateUpdate()
    {
        _rectTransform.position = Input.mousePosition;
    }
}
