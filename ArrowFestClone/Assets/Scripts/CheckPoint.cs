using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public TrackCheckpoints trackCheckpoints;
    [SerializeField] public bool isArrowGoThrough = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ParentArrow>(out ParentArrow parentArrow));
        {
            if(IsArrowGoThrough() == false)
            {
                trackCheckpoints.ArrowThroughCheckpoint(this);
                trackCheckpoints.IsArrowGoThroughOtherGate(this);
                isArrowGoThrough = true;
            }
        }
    }

    public void SetTrackCheckpoints(TrackCheckpoints trackCheckpoints)
    {
        this.trackCheckpoints = trackCheckpoints;
    }
    public bool IsArrowGoThrough()
    {
        return isArrowGoThrough;
    }
}
