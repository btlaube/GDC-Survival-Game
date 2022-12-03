using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HeathbarScript : MonoBehaviour
{

    //private PlayerHealth playerHealth;
    //[SerializeField] private TMP_Text healthText;

    //void Update() {
    //    playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    //    if(playerHealth) {
    //        healthText.text = "Health: " + playerHealth.currentHealth.ToString();
    //    }
    //}


    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    void Update() {        
        if(SceneManager.GetActiveScene().buildIndex == 1) {
            playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
            totalHealthBar.fillAmount = playerHealth.maxHealth / 10;
            currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
        }        
    }
}
