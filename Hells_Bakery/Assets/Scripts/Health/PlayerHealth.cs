using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] public float currentHealth;
    [SerializeField] public float maxHealth;
    private bool dead;
    [SerializeField] private Behaviour[] components;

    private void Awake() {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float damage) {
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0) {
            //audioManager.Play("PlayerHit");
        }
        else {
            if(!dead) {

                foreach(Behaviour comp in components) {
                    comp.enabled = false;
                }

                dead = true;
            }            
        }
    }

    public void Deactivate() {
        Destroy(gameObject);
    }

    public void NewRound() {
        dead = false;
        transform.position = new Vector3(0f, 0f, 0f);
        //clear all enemies
        currentHealth = 10f;
        GetComponent<PlayerMovement>().score = 0f;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        foreach (Transform enemy in enemySpawner.GetComponent<Transform>()) {
            Destroy(enemy.gameObject);
        }
        enemySpawner.GetComponent<EnemySpawner>().waveSize = 5f;
        enemySpawner.GetComponent<EnemySpawner>().waveRate = 5f;
    }

    public void Update() {
        if(dead) {
            //Debug.Log("enemy died");
            //Deactivate();
            NewRound();
        }
    }
}
