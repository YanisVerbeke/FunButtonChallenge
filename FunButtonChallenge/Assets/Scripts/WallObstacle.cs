using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        transform.localScale = new Vector3(Random.Range(2, 8) * 50, Random.Range(1, 4) * 50, 50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
