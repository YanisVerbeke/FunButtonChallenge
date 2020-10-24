using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerRotation : MonoBehaviour
{
    float timeCounter = 0;
    public Vector3 direction;

    public void StartRotation()
    {
        timeCounter += Time.deltaTime * 5;
        float x = Mathf.Cos(timeCounter);
        float y = Mathf.Sin(timeCounter);
        direction = new Vector3(x, y, 0);
        transform.localPosition = direction * 0.5f;
        
    }
}
