using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ExpPlus.Phariables;

public class LinkIntPhariableToText : MonoBehaviour
{
    [SerializeField]
    private TMP_Text text;

    [SerializeField]
    private IntPhariable intPhariable;

    [SerializeField]
    private bool leadingZero = true;

    // Update is called once per frame
    void Update()
    {

        string textString = intPhariable.value.ToString();

        if (leadingZero)
        {
            if (intPhariable.value < 10)
                textString = "0" + intPhariable.value.ToString();
        }

        text.text = textString;
    }
}
