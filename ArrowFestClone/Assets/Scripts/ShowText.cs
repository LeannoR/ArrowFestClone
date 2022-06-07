using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{

    [SerializeField] public string gateNumber;
    [SerializeField] public TextMeshProUGUI textElement;
    public static ShowText instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public int GetValueFromText()
    {
        string charvalue = "";
        int value = 0;
        for(int i = 1; i < textElement.text.Length; i ++)
        {
            charvalue = charvalue + textElement.text[i].ToString();
        }
        value = int.Parse(charvalue);
        return value;
    }

    public string GetOperatorFromText()
    {
        string operatorValue = textElement.text[0].ToString();
        return operatorValue;
    }
}
