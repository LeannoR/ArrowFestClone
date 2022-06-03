using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowArrow : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    public Transform arrows;
    void Update()
    {
        transform.position = arrows.position + offset; 
    }
}
