using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraFollow : MonoBehaviour
{
    public float trackingSpeed;
    public float minX;
    public float minZ;
    public float maxX;
    public float maxZ;
    public static CameraFollow instance;

    [SerializeField] private Transform camTarget;

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

    void FixedUpdate() {
        if (camTarget != null) {
            var newPos = Vector3.Lerp(transform.position, new Vector3(camTarget.position.x, transform.position.y, camTarget.position.z - 10f), Time.deltaTime * trackingSpeed);
            var camPosition = new Vector3(newPos.x, 10f, newPos.z);
            var v3 = camPosition;
            var clampX = Mathf.Clamp(v3.x, minX, maxX);
            var clampZ = Mathf.Clamp(v3.z, minZ, maxZ);
            transform.position = new Vector3(clampX, 10f, clampZ);
        }
    }
}
