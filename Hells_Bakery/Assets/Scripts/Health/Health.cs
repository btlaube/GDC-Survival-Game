using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] public float currentHealth;
    //public GameObject enemyDrop;

    //private AudioManager audioManager;
    //private Animator animator;
    private bool dead;
    [SerializeField] private Behaviour[] components;

    private void Awake() {
        currentHealth = startingHealth;
        //animator = GetComponent<Animator>();
        //audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    public void TakeDamage(float damage) {
        //Debug.Log("took damage");
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if(currentHealth > 0) {
            //audioManager.Play("PlayerHit");
        }
        else {
            if(!dead) {
                //audioManager.Play("PlayerDie");
                //animator.SetTrigger("Die");

                //TODO change to child collider
                //GetComponent<Collider>().enabled = false;

                foreach(Behaviour comp in components) {
                    comp.enabled = false;
                }

                dead = true;

                //Instantiate(enemyDrop, transform.position, Quaternion.identity);
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
        Transform enemySpawner = GameObject.Find("EnemySpawner").GetComponent<Transform>();
        foreach (Transform enemy in enemySpawner) {
            Destroy(enemy.gameObject);
        }
    }

    public void Update() {
        if(dead) {
            Deactivate();
        }
    }
}
