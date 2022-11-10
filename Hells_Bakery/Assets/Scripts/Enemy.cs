using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    private Transform player;
    private NavMeshAgent enemy;

    void Start() {
        player = GameObject.Find("Player").transform;
        enemy = gameObject.GetComponent<NavMeshAgent>();
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
}
