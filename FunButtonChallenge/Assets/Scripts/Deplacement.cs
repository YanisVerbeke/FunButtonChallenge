using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    public Rigidbody rigidbody;
    [SerializeField]
    int speed;
    public Vector3 previousVel;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(speed, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -260)
        {
            //
        }
        if (transform.position.x > 260)
        {
            //
            
        }
    }


}
