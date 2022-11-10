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
        Debug.Log("took damage");
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

    public void Update() {
        if(dead) {
            Debug.Log("enemy died");
            Deactivate();
        }
    }
}
