using UnityEngine;
using UnityEngine.UI;

public class HeathbarScript : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    //void Update() {
    //    playerHealth = GameObject.Find("Player").GetComponent<Health>();
    //    if(playerHealth) {
    //        totalHealthBar.fillAmount = playerHealth.maxHealth / 10;
    //        currentHealthBar.fillAmount = playerHealth.currentHealth.runtimeAmount / 10;
    //    }        
    //}
}
