using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] private float lifeSpan = 5f;
    private float timer;

    void Start() {
        float timer = Time.deltaTime;
    }

    void Update() {
        timer += Time.deltaTime;
        // Convert integer to string
        if (timer >= lifeSpan) {
            Destroy(gameObject);
        }
    }
}