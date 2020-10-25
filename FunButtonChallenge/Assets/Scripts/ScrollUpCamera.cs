using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollUpCamera : MonoBehaviour
{
    private GameObject player;
    private PlayerControler playerScript;
    private int cameraOffset = 100;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= transform.position.y + cameraOffset)
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y - cameraOffset, transform.position.z);
        }
        if (player.transform.position.y < transform.position.y - 370)
        {
            player.SetActive(false);
        }
    }
}
