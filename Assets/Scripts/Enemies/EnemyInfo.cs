using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyInfo : MonoBehaviour
{
    private NavMeshAgent navAgent;
    
    [SerializeField][Min(1)]
    float health;
    [SerializeField][Min(0)]
    float speed;
    [SerializeField][Min(0)]
    float damage;

    [SerializeField]
    float detectRange;
    [SerializeField]
    float attackRange;
    private Transform detectRg;
    private Transform attackRg;
    private bool showRange;
    
    // Start is called before the first frame update
    void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        
        detectRg = transform.Find("DetectRange");
        attackRg = transform.Find("AttackRange");
        detectRg.localScale = new Vector3(detectRange * 2, 0.05f, detectRange * 2);
        attackRg.localScale = new Vector3(attackRange * 2, 0.1f, attackRange * 2);
        showRange = false;

        navAgent.stoppingDistance = attackRange;
        navAgent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
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
    }

    public float GetDetectRange() {
        return detectRange;
    }

    public float GetAttackRange() {
        return attackRange;
    }
    
    public float GetDamage() {
        return damage;
    }
}
