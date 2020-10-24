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

    GameObject player;
    GameObject pointer;
    PlayerControler playerScript;
    PointerRotation pointerScript;
    bool previousVelStocked = false;
    bool maxPower = false;

    private void Start()
    {
        player = GameObject.Find("Player");
        pointer = GameObject.Find("Pointer");
        playerScript = player.GetComponent<PlayerControler>();
        pointerScript = pointer.GetComponent<PointerRotation>();
    }

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
            pointerScript.StartRotation();
            playerScript.ShakeBall(true);
            pointerDownTimer += Time.fixedDeltaTime;
            if (pointerDownTimer >= requireHoldTime)
            {
                maxPower = true;
            }
            Debug.Log("Timer : " + pointerDownTimer);
            if (!maxPower)
            {
                StopBall();
            }
        }
    }

    public void StopBall()
    {
        if (!previousVelStocked)
        {
            Debug.Log(pointerScript.direction);
            playerScript.previousVel = pointerScript.direction * playerScript.speed;
            previousVelStocked = true;
            Debug.Log(playerScript.previousVel);
        }
        playerScript.rigidbody.velocity = Vector3.zero;
        playerScript.speed *= 1.012f;
        playerScript.shakeAmt *= 1.01f;
    }

    private void Reset()
    {
        previousVelStocked = false;
        pointerDown = false;
        maxPower = false;
        pointerDownTimer = 0;
        //playerScript.rigidbody.velocity = Vector3.Scale(playerScript.previousVel, pointerScript.direction);
        playerScript.rigidbody.velocity = pointerScript.direction * playerScript.speed;
        playerScript.speed = 100;
        playerScript.ShakeBall(false);
        playerScript.shakeAmt = 100;
        pointerScript.transform.localPosition = new Vector3(0, 0, 0);
    }
}
