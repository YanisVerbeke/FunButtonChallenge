using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapObstacle : MonoBehaviour
{
    int trapSize;
    private GameObject player;

    void Awake()
    {
        trapSize = Random.Range(1, 5);
        transform.localScale = new Vector3(trapSize * 50, trapSize * 50, 50);
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.SetActive(false);
        }
    }
}
