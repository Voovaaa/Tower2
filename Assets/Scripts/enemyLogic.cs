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
    public float knockbackPower;

    public GameObject model;

    Animator animator;

    bool isAiActive;
    NavMeshAgent navMeshAgent;
    GameObject player;
    ParticleSystem particles;
    Rigidbody rb;
    float disablingPhysicsDelay;
    private void Start()
    {
        animator = model.GetComponent<Animator>();
        disablingPhysicsDelay = 10f;
        currentHp = maxHp;
        attackCooldown = 0;
        navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("player");
        particles = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        isAiActive = true;
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
        AIAction();
    }


    public void AIAction()
    {
        if (!isAiActive) { return; }
        if (Vector3.Distance(player.transform.position, transform.position) <= attackRadius && attackCooldown <= 0)
        {
            animator.SetBool("walking", false);
            attack();
        }
        else if(Vector3.Distance(player.transform.position, transform.position) <= agressiveRadius)
        {
            animator.SetBool("walking", true);
            moveToPlayer();
        }
        else
        {
            navMeshAgent.isStopped = true;
            animator.SetBool("walking", false);
        }
    }
    public void moveToPlayer()
    {
        navMeshAgent.isStopped = false;
        navMeshAgent.SetDestination(player.transform.position);
    }
    public void attack()
    {
        navMeshAgent.isStopped = true;
        transform.LookAt(player.transform.position);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); 
    }

    public void gotDamage(float damage)
    {
        particles.Play();
        currentHp -= damage;
        knockback();
        if (currentHp <= 0)
        {
            die();
        }
    }

    public void die()
    {
        animator.SetBool("isDead", true);
        isAiActive = false;
        navMeshAgent.enabled = false;
        rb.constraints = RigidbodyConstraints.None;
        Invoke("disablePhysics", disablingPhysicsDelay);
    }
    public void disablePhysics()
    {
        rb.useGravity = false;
        transform.GetComponent<Collider>().enabled = false;
    }

    public void knockback()
    {
        Vector3 knockbackVector = transform.forward * -1 + transform.up;
        rb.AddForce(knockbackVector * knockbackPower, ForceMode.Impulse);
    }
}
