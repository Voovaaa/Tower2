using UnityEngine;
using UnityEngine.AI;

public class enemyLogic : MonoBehaviour, IAttackable
{
    public float maxHp;
    public float currentHp;
    public float damage;
    public float moveSpeed;
    public float attackSpeed;
    public float attackCooldown;
    public float agressiveRadius;
    public float attackRadius;

    NavMeshAgent navMeshAgent;
    CharacterController controller;
    GameObject player;

    private void Start()
    {
        currentHp = maxHp;
        attackCooldown = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("player");
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        AIAction();
    }


    public void AIAction()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= attackRadius && attackCooldown <= 0)
        {
            attack();
        }
        else if(Vector3.Distance(player.transform.position, transform.position) <= agressiveRadius)
        {
            moveToPlayer();
        }
    }
    public void moveToPlayer()
    {
        navMeshAgent.SetDestination(player.transform.position);
    }
    public void attack()
    {
        navMeshAgent.isStopped = true;
        transform.LookAt(player.transform.position);

    }

    public void gotDamage(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            die();
        }
    }

    public void die()
    {

    }
}
