using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGroupScript : MonoBehaviour
{
    public static CanvasGroupScript instance;
    public float slowedTimeScale = 0.5f;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
        else {
            Destroy(gameObject);
            return;
        }
    
        DontDestroyOnLoad(gameObject);
    }

    public void Update() {
        if(Input.GetKey(KeyCode.LeftShift)) {
            OpenSelectMenu();
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)) {
            CloseSelectMenu();
        }
        if (Input.GetKey(KeyCode.P)) {
            OpenPauseMenu();
        }
    }

    public void LoadMainMenu() {
        foreach(Transform canvas in transform) {
            canvas.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void LoadGameScene() {
        foreach(Transform canvas in transform) {
            canvas.gameObject.SetActive(false);
        }
        transform.GetChild(0).gameObject.SetActive(true);
        transform.GetChild(2).gameObject.SetActive(true);
        transform.GetChild(4).gameObject.SetActive(true);
    }

    private void OpenSelectMenu() {
        Time.timeScale = slowedTimeScale;
        this.gameObject.transform.GetChild(3).gameObject.SetActive(true);
    }

    private void CloseSelectMenu() {
        Time.timeScale = 1f;
        this.gameObject.transform.GetChild(3).GetChild(1).GetComponent<InventoryDial>().SetSelection();
        this.gameObject.transform.GetChild(3).gameObject.SetActive(false);
    }

    public void OpenPauseMenu() {
        Time.timeScale = 0f;
        transform.GetChild(5).gameObject.SetActive(true);
    }

    public void ClosePauseMenu() {
        Time.timeScale = 1f;
        transform.GetChild(5).gameObject.SetActive(false);
    }

}
