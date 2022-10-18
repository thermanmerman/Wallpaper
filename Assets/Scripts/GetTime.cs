using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Globalization;

public class GetTime : MonoBehaviour
{
    public TMP_Text dateTimeText;

    void Update()
    {
        dateTimeText.text = DateTime.Now.ToString();
    }
}
