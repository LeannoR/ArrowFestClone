using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ParentArrow : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI arrowCountText;

    public static ParentArrow instance;
    public List<GameObject> arrows = new List<GameObject>();
    public GameObject parentArrow;
    public Transform transformParent;

    public float ArrowGap = .5f;
    public float RadiusIncrease = 1f;
    public float degree = 1f;
    public float circleLength = 1f;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void Update()
    {
        DisplayArrowCount();
    }

    public void CreatingArrows(int value)
    {
        for (int i = arrows.Count; i < value; i++)
        {
            GameObject newArrow = Instantiate(arrows[0], transformParent);
            arrows.Add(newArrow);
            newArrow.transform.parent = transform;
        }
        ArrowPosition();
    }
    public void DestroyArrows(int value)
    {
        for (int i = 0; i < value; i ++)
        {
            Destroy(arrows[arrows.Count - 1]);
            arrows.RemoveAt(arrows.Count - 1);
        }
        ArrowPosition();
    }

    public void ArrowPosition()
    {
        arrows[0].transform.localPosition = Vector3.zero;
        var i = 1;
        var r = RadiusIncrease;
        while(i < arrows.Count)
        {
            var length = 2 * Mathf.PI * r;
            var arrowCount = length / ArrowGap;
            var angle = 360f / arrowCount;
            for (var j = 0; j < arrowCount && i < arrows.Count; j++, i++)
            {
                var arrowPos = Quaternion.AngleAxis(angle * j, Vector3.forward) * Vector3.up * r;
                arrows[i].transform.localPosition = arrowPos;
            }
            r += RadiusIncrease;
        }
    }
    public void DisplayArrowCount()
    {
        int arrowsCount = arrows.Count;
        arrowCountText.text = arrowsCount.ToString();
    }

}
