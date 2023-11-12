using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_Interact : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent navAgent;
    private EnemyInfo info;

    private GameObject player;

    private int idleState;
    private int runState;
    private int attackState;
    private int deathState;
    private int removeState;

    // knife's collider can enable?
    private bool knifeCollide = true;

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
        attackState = Animator.StringToHash("Base Layer.Attack");
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
            if (dis <= info.GetAttackRange()) {
                anim.SetBool("Attack", true);
            }
            else if (dis > info.GetAttackRange() && dis <= info.GetDetectRange()) {
                navAgent.SetDestination(player.transform.position);
                navAgent.isStopped = false;
            }
            else {
                navAgent.isStopped = true;
            }
            float speed = new Vector3(navAgent.velocity.x, 0f, navAgent.velocity.z).magnitude;
            anim.SetFloat("Speed", speed);
            knifeCollide = true;
        }
        else if (animState.fullPathHash == attackState) {
            // enable knife to hit player
            navAgent.isStopped = true;
            anim.SetBool("Attack", false);
            if (knifeCollide) {
                GameObject.Find(transform.name + "/Bip001/Bip001 Prop1/Knife").GetComponent<BoxCollider>().enabled = true;
                StartCoroutine(DisableKnifeCollider(1.5f));
            }  
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

    private IEnumerator DisableKnifeCollider(float second) {
        knifeCollide = false;
        yield return new WaitForSeconds(second);
        GameObject.Find(transform.name + "/Bip001/Bip001 Prop1/Knife").GetComponent<BoxCollider>().enabled = false;
    }
}
