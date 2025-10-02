using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class BrushFollower : MonoBehaviour
{
    public XRNode hand = XRNode.RightHand;
    public float followSpeed = 20f;

    void Update()
    {
        if (InputDevices.GetDeviceAtXRNode(hand).TryGetFeatureValue(CommonUsages.devicePosition, out Vector3 pos) &&
            InputDevices.GetDeviceAtXRNode(hand).TryGetFeatureValue(CommonUsages.deviceRotation, out Quaternion rot))
        {
            transform.position = Vector3.Lerp(transform.position, pos, Time.deltaTime * followSpeed);
            transform.rotation = rot;
        }
    }
}
