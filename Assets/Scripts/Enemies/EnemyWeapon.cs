using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private EnemyInfo info;

    // Start is called before the first frame update
    void Start()
    {
        info = GetComponent<EnemyInfo>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") {
            // TODO: Deal damage to player
            // ...
            // Use info.GetDamage() to get the damage this enemy can deal.
        }
    }
}
