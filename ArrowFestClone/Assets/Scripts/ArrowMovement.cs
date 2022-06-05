using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 30f;
    [SerializeField] float sidewaySpeed = 2f;
    public float Multiplier = 1f;
    public float ScaleMultiplier = 1f;

    private Vector3 previousMousePos;
    void Update()
    {
        ForwardMovement();
        SideWaySwipe();
        LockHorizontalPosition();
        LockScale();
    }

    void ForwardMovement()
    {
        transform.position = transform.position + Vector3.forward * forwardSpeed * Time.deltaTime;
    }
    public void SideWaySwipe()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            previousMousePos = Input.mousePosition;
        }
        else if(Input.GetKey(KeyCode.Mouse0))
        {
            var newpos = Input.mousePosition;
            var difpos = newpos - previousMousePos;
            var horizontal = difpos.x * Time.deltaTime * Multiplier;
            var horizontalScale = difpos.x * Time.deltaTime * ScaleMultiplier;

            if(transform.position.x > 0)
            {
                transform.localScale = transform.localScale - transform.right * horizontalScale;
            }
            else if(transform.position.x < 0)
            {
                transform.localScale = transform.localScale + transform.right * horizontalScale;
            }

            transform.position = transform.position + transform.right * horizontal;
        }
    }

    public void LockHorizontalPosition()
    {
        var pos = transform.position;
        pos.x = Mathf.Clamp(transform.position.x, -10, 10);
        transform.position = pos;
    }
    public void LockScale()
    {
        var scale = transform.localScale;
        scale.x = Mathf.Clamp(transform.localScale.x, 1, 2);
        transform.localScale = scale;
    }
}
