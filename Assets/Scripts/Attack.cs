using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DirectionOption
{
    Forward,
    Back,
    Up,
    Down,
    Right,
    Left,
}

public class Attack : MonoBehaviour
{
    public float radius = 0.3f;
    public float length = 1f;

    public string targetTag = "Player";

    public int decreaseDelta = 1;

    public Status status;

    public DirectionOption directionOption;


    // Update is called once per frame
    void Update()
    {

        Vector3 direction = Vector3.zero;

        switch (directionOption)
        {
            case DirectionOption.Forward:
                direction = transform.forward;
                break;
            case DirectionOption.Back:
                direction = -transform.forward;
                break;
            case DirectionOption.Up:
                direction = transform.up;
                break;
            case DirectionOption.Down:
                direction = -transform.up;
                break;
            case DirectionOption.Right:
                direction = transform.right;
                break;
            case DirectionOption.Left:
                direction = -transform.right;
                break;
            default:
                print("Direction Error!");
                break;
        }



        if (Physics.SphereCast(transform.position, radius, direction, out RaycastHit hit, length))
        {

            if (hit.transform.gameObject.tag == targetTag)
            {
                status = hit.transform.gameObject.GetComponent<Status>();
                status.DecreaseHP(decreaseDelta);
            }
        }

        Debug.DrawRay(transform.position, direction * length);
    }
}
