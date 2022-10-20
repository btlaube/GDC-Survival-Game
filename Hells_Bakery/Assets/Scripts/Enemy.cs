using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;
    public Transform player;
    public NavMeshAgent enemy;

    void Update() {
        enemy.SetDestination(player.position);
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("hit a player");
            other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
}
