using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeHeightSetter : MonoBehaviour
{
    public float desiredHeight = 1.6f;

    void Start()
    {
        Vector3 pos = transform.localPosition;
        pos.y = desiredHeight;
        transform.localPosition = pos;
    }
}

