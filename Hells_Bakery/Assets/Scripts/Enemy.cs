using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float damage;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            Debug.Log("hit a player");
            other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
}
