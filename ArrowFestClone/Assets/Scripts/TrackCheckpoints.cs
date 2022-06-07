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
            value = arrowsCount / value;
            ParentArrow.instance.DestroyArrows(arrowsCount - value);
        }
        else if (operatorValue == "*")
        {
            value *= arrowsCount;
            ParentArrow.instance.CreatingArrows(value);
        }
        else if (operatorValue == "-")
        {
            ParentArrow.instance.DestroyArrows(value);
        }
        else
        {
            value += arrowsCount;
            ParentArrow.instance.CreatingArrows(value);
        }
    }
    public void IsArrowGoThroughOtherGate(CheckPoint checkpoint)
    {
        int realGateNumber = int.Parse(checkpoint.GetComponent<ShowText>().gateNumber);

        foreach (GameObject Childcheckpoint in checkpoints)
        {
            CheckPoint checkPoint = Childcheckpoint.GetComponent<CheckPoint>();
            ShowText showText = Childcheckpoint.GetComponent<ShowText>();
            int gateNumber = int.Parse(showText.gateNumber);
            if(gateNumber == realGateNumber)
            {
                checkPoint.isArrowGoThrough = true;
            }
        }

    }



}
