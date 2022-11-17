using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryDial : MonoBehaviour
{
    public Vector3 activeScale = new Vector3(2f, 2f, 2f);
    public Vector3 unactiveScale = new Vector3(1f, 1f, 1f);
    public int sections;

    [SerializeField] private List<Transform> items;
    private AudioManager audioManager;
    private Transform activeItem;

    void Awake() {
        items = new List<Transform>();

        foreach (Transform item in transform) {
            items.Add(item);
        }
        sections = items.Count;
    }

    void Start() {
        audioManager = AudioManager.instance;
        foreach(Transform item in items) {
            DeactivateItem(item);
        }
    }

    void Update() {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        if(IsMouseOverUI(pointerEventData)) {
            Transform newActiveItem = DetermineSection(pointerEventData.position);
            if(newActiveItem != activeItem) {
                SetActiveItem(newActiveItem);
            }
        }

        items = new List<Transform>();

        foreach (Transform item in transform)
        {
            items.Add(item);
        }
        sections = items.Count;
    }

    private bool IsMouseOverUI(PointerEventData pointerEventData) {
        List<RaycastResult> raycastResultList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultList);
        for(int i = 0; i < raycastResultList.Count; i++) {
            if(raycastResultList[i].gameObject == gameObject) {
                return true;
            }
        }
        return false;
    }

    private Transform DetermineSection(Vector2 mousePosition) {
        float slope = (mousePosition.y - transform.position.y)/(mousePosition.x - transform.position.x);

        float minDist = Mathf.Infinity;
        Transform closestPoint = items[0];
        foreach(Transform item in items) {
            if((Vector2.Distance(mousePosition, item.position)) < minDist) {
                minDist = Vector2.Distance(mousePosition, item.position);
                closestPoint = item;
            }
        }

        return closestPoint;        
    }

    private void SetActiveItem(Transform newActiveItem) {
        foreach(Transform item in items) {
            if(item == newActiveItem) {
                ActivateItem(item);
            }
            else {
                DeactivateItem(item);
            }
        }
    }

    private void ActivateItem(Transform item) {
        audioManager.Play("Chirp");
        item.gameObject.SetActive(true);
        item.localScale = activeScale;
        activeItem = item;
    }

    private void DeactivateItem(Transform item) {
        item.localScale = unactiveScale;
        item.gameObject.SetActive(false);
    }

    public void SetSelection() {
        foreach(Transform item in transform) {
            if(item.gameObject.activeSelf) {
                Debug.Log(item);
            }
        }
    }

}
