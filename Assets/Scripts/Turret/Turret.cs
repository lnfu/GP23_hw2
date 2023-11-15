using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Turret : MonoBehaviour
{
    [Range(0, 180f)] public float angle = 45f;

    public float maxTurnSpeed = 90f;

    public Transform target;
    public GameObject Former;
    [HideInInspector] public bool outOfRange;
    [HideInInspector] public bool aimed;

    void Update()
    {
        Aim(target.position);
    }

    void Aim(Vector3 targetPoint)
    {
        var turret = transform;
        var hardpoint = turret.parent;

        var direction = targetPoint - turret.position;
        direction = Vector3.ProjectOnPlane(direction, hardpoint.up);
        var signedAngle = Vector3.SignedAngle(hardpoint.forward, direction, hardpoint.up);

        outOfRange = false;
        if (Mathf.Abs(signedAngle) > angle)
        {
            outOfRange = true;
            direction = hardpoint.rotation * Quaternion.Euler(0, Mathf.Clamp(signedAngle, -angle, angle), 0) *
                        Vector3.forward;
        }

        var rotation = Quaternion.LookRotation(direction, hardpoint.up);

        aimed = false;
        if (rotation == transform.rotation && !outOfRange)
        {
            aimed = true;
        }

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, maxTurnSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player"&&Former==null)
        {
            Destroy(gameObject);
        }
    }
}

