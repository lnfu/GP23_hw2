using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        transform.position += new Vector3(-Input.GetAxis("Horizontal"), 0, -Input.GetAxis("Vertical")) * 0.1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyWeapon") {
            Debug.Log("Hurt by " + other.name);
        }
    }
}
