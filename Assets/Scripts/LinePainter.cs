using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LinePainter : MonoBehaviour
{
    public GameObject linePrefab;
    public Transform drawOrigin; // NUEVO: punto desde donde sale la pintura
    public XRNode controllerNode = XRNode.RightHand;
    public float minDistance = 0.005f;

    private LineRenderer currentLine;
    private List<Vector3> points = new List<Vector3>();
    private bool isDrawing = false;
    private Vector3 lastPoint;

    void Update()
    {
        InputDevices.GetDeviceAtXRNode(controllerNode).TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed);

        if (triggerPressed && !isDrawing)
        {
            StartLine();
        }
        else if (!triggerPressed && isDrawing)
        {
            EndLine();
        }

        if (isDrawing && drawOrigin != null)
        {
            Vector3 currentPosition = drawOrigin.position;

            if (Vector3.Distance(currentPosition, lastPoint) >= minDistance)
            {
                AddPoint(currentPosition);
            }
        }
    }

    void StartLine()
    {
        GameObject newLine = Instantiate(linePrefab);
        currentLine = newLine.GetComponent<LineRenderer>();
        points.Clear();
        AddPoint(drawOrigin.position);
        isDrawing = true;
    }

    void EndLine()
    {
        isDrawing = false;
        currentLine = null;
    }

    void AddPoint(Vector3 point)
    {
        points.Add(point);
        currentLine.positionCount = points.Count;
        currentLine.SetPositions(points.ToArray());
        lastPoint = point;
    }
}

