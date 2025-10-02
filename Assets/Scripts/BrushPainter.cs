using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BrushPainter : MonoBehaviour
{
    public TrailRenderer trail;
    public XRNode controllerNode = XRNode.RightHand;

    void Start()
    {
        //trail = GetComponent<TrailRenderer>();
        trail.emitting = false;
    }

    void Update()
    {
        InputDevices.GetDeviceAtXRNode(controllerNode).TryGetFeatureValue(CommonUsages.triggerButton, out bool triggerPressed);
        trail.emitting = triggerPressed;
    }
}

