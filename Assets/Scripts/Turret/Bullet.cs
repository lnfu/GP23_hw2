using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;

    Rigidbody rb;
    Vector3 velocity;


    void Start()
    {
        Destroy(gameObject, 2.0f);
    }

    void FixedUpdate()
    {
       
    }

    

     /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
