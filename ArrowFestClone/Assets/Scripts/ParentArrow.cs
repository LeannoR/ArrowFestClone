using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentArrow : MonoBehaviour
{
    [SerializeField] public Text arrowCountText;

    public static ParentArrow instance;
    public List<GameObject> arrows = new List<GameObject>();
    public GameObject parentArrow;
    public Transform transformParent;

    public float radius = 0.1f;
    public float degree = 1f;

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
        PositioningArrows();
    }
    public void DestroyArrows(int value)
    {
        for (int i = 0; i < value; i ++)
        {
            Destroy(arrows[arrows.Count - 1]);
            arrows.RemoveAt(arrows.Count - 1);
        }
        PositioningArrows();
    }

    public void PositioningArrows()
    {
        degree = 360 / arrows.Count;
        
        for(int i = 0; i < arrows.Count; i++)
        {
            MoveObjects(arrows[i].transform, i * degree);
        }
    }

    public void MoveObjects(Transform newObjectTransform, float degree)
    {
        radius += 0.05f;
        Vector3 newPos = Vector3.zero;
        newPos.x = Mathf.Cos(degree * Mathf.Deg2Rad);
        newPos.y = Mathf.Sin(degree * Mathf.Deg2Rad);
        newObjectTransform.localPosition = newPos;
    }
    public void DisplayArrowCount()
    {
        int arrowsCount = arrows.Count;
        arrowCountText.text = arrowsCount.ToString();
    }

}
