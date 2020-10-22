using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class FunHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool pointerDown;
    private float pointerDownTimer;

    public float requireHoldTime;

    [SerializeField]
    GameObject sphere;
    Deplacement sphereScript;
    Vector3 spherePreviousVel;
    bool previousVelStocked = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
        //Debug.Log("Down");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
        //Debug.Log("Up");
    }
    void Update()
    {
        if (pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if (pointerDownTimer >= requireHoldTime)
            {
                Reset();
            }
            Debug.Log("Timer : " + pointerDownTimer);
            StopBall();
        }
    }

    public void StopBall()
    {
        sphereScript = sphere.GetComponent<Deplacement>();
        if (!previousVelStocked)
        {
            sphereScript.previousVel = sphereScript.rigidbody.velocity;
            previousVelStocked = true;
            Debug.Log(sphereScript.previousVel);
        }
        sphereScript.rigidbody.velocity = Vector3.zero;
        sphereScript.previousVel *= 1.002f;
    }

    private void Reset()
    {
        previousVelStocked = false;
        pointerDown = false;
        pointerDownTimer = 0;
        sphereScript.rigidbody.velocity = sphereScript.previousVel;
    }
}
