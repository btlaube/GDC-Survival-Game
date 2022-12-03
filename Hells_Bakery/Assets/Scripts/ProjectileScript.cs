using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float damage = 10f;
    [SerializeField] private float lifeSpan = 5f;
    [SerializeField] private PlayerMovement player;
    private float timer;

    void Start() {
        timer = Time.deltaTime;
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= lifeSpan) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Enemy") {
            player.score += 2f;
            other.gameObject.GetComponentInParent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
