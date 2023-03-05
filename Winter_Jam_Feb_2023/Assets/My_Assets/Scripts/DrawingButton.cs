using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DrawingButton : MonoBehaviour
{
    private Button btn;
    public Image img;
    public Color activateColor, deactivateColor;

    public bool isActive;
    public Joystick js;

    private void Awake()
    {
        isActive = true;
        btn = GetComponent<Button>();

        btn.onClick.AddListener(Toggle);
    }

    void Toggle()
    {
        if (isActive)
            Deactivate();
        else
        {
            Activate();
        }
    }


    void Activate()
    {
        img.color = activateColor;
        isActive = true;
        Line_Drawer._instance.canDraw = true;
        js.gameObject.SetActive(false);
    }

    void Deactivate()
    {
        img.color = deactivateColor;
        isActive = false;
        Line_Drawer._instance.EndDraw();
        Line_Drawer._instance.canDraw = false;
        js.gameObject.SetActive(true);
    }
}