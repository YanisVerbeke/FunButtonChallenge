using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public Rigidbody rigidbody;
    [SerializeField]
    public float speed;
    public Vector3 previousVel;
    private bool shaking = false;
    public float shakeAmt = 100;
    private bool savedPos = false;
    Vector3 originalPos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (shaking)
        {
            if (!savedPos)
            {
                originalPos = transform.position;
                savedPos = true;
            }
            Vector3 newPos = originalPos + Random.insideUnitSphere * (Time.deltaTime * shakeAmt);
            newPos.z = transform.position.z;
            transform.position = newPos;
        } else
        {
            savedPos = false;
        }
    }

    public void ShakeBall(bool shaking)
    {
        this.shaking = shaking;
    }
}
