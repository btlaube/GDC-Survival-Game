using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HeathbarScript : MonoBehaviour
{

    private Health playerHealth;
    [SerializeField] private TMP_Text healthText;

    void Update() {
        playerHealth = GameObject.Find("Player").GetComponent<Health>();
        if(playerHealth) {
            healthText.text = "Health: " + playerHealth.currentHealth.ToString();
        }
    }


    //[SerializeField] private Health playerHealth;
    //[SerializeField] private Image totalHealthBar;
    //[SerializeField] private Image currentHealthBar;

    //void Update() {
    //    playerHealth = GameObject.Find("Player").GetComponent<Health>();
    //    if(playerHealth) {
    //        totalHealthBar.fillAmount = playerHealth.maxHealth / 10;
    //        currentHealthBar.fillAmount = playerHealth.currentHealth.runtimeAmount / 10;
    //    }        
    //}
}
