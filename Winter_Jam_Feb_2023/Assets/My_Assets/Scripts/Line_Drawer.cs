using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Drawer : MonoBehaviour
{
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    int cantDrawOverLayerIndex, lineLayer;

    [Space(30f)] public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;
    public float radius;
    Line currentLine;
    public bool canDraw;
    public static Line_Drawer _instance;
    Camera cam;

    void Start()
    {
        canDraw = true;
        _instance = this;
        cam = Camera.main;
        cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
        lineLayer = LayerMask.NameToLayer("Line");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            BeginDraw();

        if (currentLine != null)
            Draw();

        if (Input.GetMouseButtonUp(0))
            EndDraw();
    }

    // Begin Draw ----------------------------------------------
    void BeginDraw()
    {
        if (!canDraw)
            return;
        currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

        //Set line properties
        currentLine.UsePhysics(false);
        currentLine.SetLineColor(lineColor);
        currentLine.SetPointsMinDistance(linePointsMinDistance);
        currentLine.SetLineWidth(lineWidth);
    }

    // Draw ----------------------------------------------------
    void Draw()
    {
        Vector2 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        //Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero, 1f, cantDrawOverLayer);

        if (hit)
        {
            EndDraw();
            Debug.Log(hit.collider.name);
        }
        else
            currentLine.AddPoint(mousePosition);
    }

    // End Draw ------------------------------------------------
    public void EndDraw()
    {
        if (!canDraw)
            return;


        if (currentLine != null)
        {
            if (currentLine.pointsCount < 2)
            {
                //If line has one point
                Destroy(currentLine.gameObject);
            }
            else
            {
                //Add the line to "CantDrawOver" layer

                currentLine.gameObject.layer = lineLayer;

                //Activate Physics on the line
                currentLine.UsePhysics(true);

                currentLine = null;
            }
        }
    }
}