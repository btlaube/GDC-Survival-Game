using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float lifeSpan = 5f;
    private float timer;

    void Start() {
        timer = Time.deltaTime;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= lifeSpan) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        damage = 1;
        if(other.gameObject.tag == "Enemy") {
            Debug.Log("hit an enemy");
            other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
        }
    }
}
