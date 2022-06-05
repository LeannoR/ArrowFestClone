using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArrow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public Transform arrows;
    void Update()
    {
        CameraPosition();
    }
    public void CameraPosition()
    {
        var cameraPos = arrows.position + offset;
        cameraPos.x = Mathf.Clamp(0, 0, 0);
        transform.position = cameraPos;
    }
}
