using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
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
}
