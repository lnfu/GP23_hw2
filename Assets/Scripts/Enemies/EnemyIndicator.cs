using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicator : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Camera.main.transform.position;
        Vector3 playerPos = player.transform.position;
        cameraPos.y = transform.position.y;
        playerPos.y = transform.position.y;
        transform.LookAt(cameraPos);

        if ((transform.position - playerPos).magnitude < 8f) {
            GetComponent<SpriteRenderer>().enabled = false;
        }
        else {
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
