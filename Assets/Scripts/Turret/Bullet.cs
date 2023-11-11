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

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
