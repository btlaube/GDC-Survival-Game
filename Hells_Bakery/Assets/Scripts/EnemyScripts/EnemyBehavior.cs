using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public EnemyObject enemyObject;

    [SerializeField] private float damage;
    private Transform player;
    private NavMeshAgent enemy;
    public float attackCooldown;
    private float attackTimer;
    

    void Start() {
        player = GameObject.Find("Player").transform;
        enemy = gameObject.GetComponent<NavMeshAgent>();
        GetComponent<SpriteRenderer>().sprite = enemyObject.sprite;
        transform.localScale = new Vector3(enemyObject.scale, enemyObject.scale, enemyObject.scale);
        damage = enemyObject.attackDamage;
        attackTimer = Time.deltaTime;
    }

    void Update() {
        attackTimer += Time.deltaTime;
        enemy.SetDestination(player.position);
        transform.Rotate(60, 0, 0);
    }

    void OnTriggerEnter(Collider other) {
        if (attackTimer >= attackCooldown){
            if(other.gameObject.tag == "Player") {
                other.gameObject.GetComponentInParent<PlayerHealth>().TakeDamage(damage);
                attackTimer = Time.deltaTime;
            }
        }        
    }
}
