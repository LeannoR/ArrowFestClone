using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 30f;
    [SerializeField] float sidewaySpeed = 2f;
    public Camera camera;
    

    Vector3 mousePos;
    float mousePosX;
    Vector3 hitPos;
    void Start()
    {
        camera = Camera.main;
        LockMouseCursor();
        
    }
    void Update()
    {
        ForwardMovement();
        SideWayMovement();
    }

    void ForwardMovement()
    {
        transform.position = transform.position + Vector3.forward * forwardSpeed * Time.deltaTime;
    }
    void SideWayMovement()
    {
        mousePos = Input.mousePosition;
        mousePos.z = camera.transform.localPosition.z;
        RaycastHit hit;
        if (Physics.Raycast(camera.ScreenPointToRay(mousePos), out hit, Mathf.Infinity));
        {
            GameObject firstArrow = ParentArrow.instance.arrows[0];
            firstArrow.transform.localRotation = Quaternion.Euler(90, 0, 0);
            hitPos = hit.point;
            hitPos.y = firstArrow.transform.localPosition.y;
            hitPos.z = firstArrow.transform.localPosition.z;
            firstArrow.transform.localPosition = Vector3.MoveTowards(firstArrow.transform.localPosition,hitPos,Time.deltaTime * sidewaySpeed);
        }
    }

    void LockMouseCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LimitVertical()
    {
        mousePosX = Mathf.Clamp(mousePosX, -10, 10);
    }


    bool isTouchingScreen()
    {
        if(Input.touchCount == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
