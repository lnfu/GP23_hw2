using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy1_Interact : MonoBehaviour
{
    private Rigidbody rb;
    private Animator anim;
    private NavMeshAgent navAgent;

    private GameObject player;

    [SerializeField]
    float health = 100f;
    [SerializeField]
    float damage = 10f;

    private int idleState;
    private int runState;
    private int attackState;
    private int damageState;
    private int deathState;
    private int removeState;

    private bool showRange;
    public float detectRange = 8f;
    private Transform detectRg;
    public float attackRange = 2f;
    private Transform attackRg;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        navAgent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player");

        idleState = Animator.StringToHash("Base Layer.Stand");
        runState = Animator.StringToHash("Base Layer.Run");
        attackState = Animator.StringToHash("Base Layer.Attack");
        damageState = Animator.StringToHash("Base Layer.Damage");
        deathState = Animator.StringToHash("Base Layer.Death");
        removeState = Animator.StringToHash("Base Layer.Exit");

        showRange = false;
        detectRg = transform.Find("DetectRange");
        attackRg = transform.Find("AttackRange");
        // navAgent.stoppingDistance = attackRange;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo animState = anim.GetCurrentAnimatorStateInfo(0);
        
        if (GetHealth() <= 0) {
            // this enemy is dead
            anim.SetBool("isDead", true);
        }

        if (animState.fullPathHash == idleState || animState.fullPathHash == runState) {
            // Detect player's position
            float dis = (transform.position - player.transform.position).magnitude;
            if (dis <= attackRange) {
                // navAgent.isStopped = true;
                anim.SetBool("Attack", true);
            }
            else if (dis > attackRange && dis <= detectRange) {
                navAgent.SetDestination(player.transform.position);
                navAgent.isStopped = false;
            }
            else {
                navAgent.isStopped = true;
            }
            float speed = new Vector3(navAgent.velocity.x, 0f, navAgent.velocity.z).magnitude;
            anim.SetFloat("Speed", speed);
        }
        else if (animState.fullPathHash == attackState) {
            // enable knife to hit player
            navAgent.isStopped = true;
            GameObject.Find(transform.name + "/Bip001/Bip001 Prop1/Knife").GetComponent<BoxCollider>().enabled = true;
            anim.SetBool("Attack", false);
        }
        else if (animState.fullPathHash == damageState) {
            navAgent.isStopped = true;
            anim.SetBool("Hurt", false);
        }
        else if (animState.fullPathHash == deathState) {
            // play dead animation
            navAgent.isStopped = true;
            // disable this enemy to collide
            transform.GetComponent<BoxCollider>().enabled = false;
        }
        else if (animState.fullPathHash == removeState) {
            // remove this enemy
            Destroy(gameObject);
        }

        if (animState.fullPathHash != attackState) {
            // disable knife to hit player
            GameObject.Find(transform.name + "/Bip001/Bip001 Prop1/Knife").GetComponent<BoxCollider>().enabled = false;
        }


        // Range Debug
        if (Input.GetKeyDown(KeyCode.O)) {
            showRange = !showRange;
            detectRg.gameObject.SetActive(showRange);
            attackRg.gameObject.SetActive(showRange);
        }
    }

    public float GetHealth() {
        return health;
    }

    public void SetHealth(float newHealth) {
        health = newHealth;
    }

    public void LoseHealth(float lose) {
        health -= lose;
        anim.SetBool("Hurt", true);
    }
}
