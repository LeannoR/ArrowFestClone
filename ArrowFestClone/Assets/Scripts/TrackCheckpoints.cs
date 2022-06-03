using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    public TrackCheckpoints instance;
    public List<GameObject> checkpoints = new List<GameObject>();
    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }

        foreach (GameObject Childcheckpoint in checkpoints)
        {
            CheckPoint checkpoint = Childcheckpoint.GetComponent<CheckPoint>();
            checkpoint.SetTrackCheckpoints(this);
        }
    }
    public void ArrowThroughCheckpoint(CheckPoint checkpoint)
    {
        ShowText textCheckpoint = checkpoint.GetComponent<ShowText>();
        int value = textCheckpoint.GetValueFromText();
        string operatorValue = textCheckpoint.GetOperatorFromText();
        CalculatingValues(operatorValue, value);
    }

    public void CalculatingValues(string operatorValue , int value)
    {
        int arrowsCount = ParentArrow.instance.arrows.Count;
        if(operatorValue == "/")
        {
            value /= arrowsCount;
            ParentArrow.instance.DestroyArrows(value);
        }
        else if (operatorValue == "*")
        {
            value *= arrowsCount;
            ParentArrow.instance.CreatingArrows(value);
        }
        else if (operatorValue == "-")
        {
            value -= arrowsCount;
            ParentArrow.instance.DestroyArrows(value);
        }
        else
        {
            value += arrowsCount;
            ParentArrow.instance.CreatingArrows(value);
        }
    }



}
