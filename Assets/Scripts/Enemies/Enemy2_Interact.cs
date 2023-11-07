using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy2_Interact : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent navAgent;
    private EnemyInfo info;

    private GameObject player;

    private int idleState;
    private int runState;
    private int deathState;
    private int removeState;

    [SerializeField]
    ParticleSystem explosion;
    private ParticleSystem explo;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();
        info = GetComponent<EnemyInfo>();

        player = GameObject.Find("Player");

        idleState = Animator.StringToHash("Base Layer.Stand");
        runState = Animator.StringToHash("Base Layer.Run");
        deathState = Animator.StringToHash("Base Layer.Death");
        removeState = Animator.StringToHash("Base Layer.Exit");
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo(0);
        
        if (info.GetHealth() <= 0) {
            // this enemy is dead
            anim.SetBool("isDead", true);
        }

        if (animState.fullPathHash == idleState || animState.fullPathHash == runState) {
            // Detect player's position
            float dis = (transform.position - player.transform.position).magnitude;
            if (dis <= info.GetDetectRange()) {
                navAgent.SetDestination(player.transform.position);
                navAgent.isStopped = false;
            }
            else {
                navAgent.isStopped = true;
            }
            float speed = new Vector3(navAgent.velocity.x, 0f, navAgent.velocity.z).magnitude;
            anim.SetFloat("Speed", speed);
        }
        else if (animState.fullPathHash == deathState) {
            // play dead animation
            navAgent.isStopped = true;
            // disable this enemy to collide
            navAgent.enabled = false;
            rb.isKinematic = true;
            transform.GetComponent<CapsuleCollider>().enabled = false;
        }
        else if (animState.fullPathHash == removeState) {
            // remove this enemy
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (info.GetHealth() > 0) {
            if (other.collider.name == "Player") {
                // TODO: Deal damage to player
                // ...
                // Use info.GetDamage() to get the damage this enemy can deal.
                
                explo = Instantiate(explosion);
                explo.transform.position = new Vector3(transform.position.x, transform.position.y + 0.9f, transform.position.z);
                Debug.Log("Exploded!");
                Destroy(gameObject);
            }
        }
    }
}
