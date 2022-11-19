using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public EnemyObject enemyObject;

    [SerializeField] private float damage;
    private Transform player;
    private NavMeshAgent enemy;
    

    void Start() {
        player = GameObject.Find("Player").transform;
        enemy = gameObject.GetComponent<NavMeshAgent>();
        GetComponent<SpriteRenderer>().sprite = enemyObject.sprite;
        transform.localScale = new Vector3(enemyObject.scale, enemyObject.scale, enemyObject.scale);
        damage = enemyObject.attackDamage;
    }

    void Update() {
        enemy.SetDestination(player.position);
        transform.Rotate(60, 0, 0);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("hit a player");
            other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }

    //public void Ability() {
    //    enemyObject = (EnemyWithAbilityObject)(enemyObject);
    //    GameObject newEnemy = Instantiate(enemyObject.enemyToSpawn, transform.position, Quaternion.identity, transform);
    //    newEnemy.GetComponent<EnemyBehavior>().enemyObject = enemyObject.enemyToSpawnObject;
    //}

}
