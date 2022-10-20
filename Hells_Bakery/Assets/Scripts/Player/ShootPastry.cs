using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPastry : MonoBehaviour
{
    public GameObject pastry;
    public float launchVelocity = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 direction = new Vector3(0, 0, 1);
        if (Physics.Raycast(ray, out RaycastHit hit, 30f))
        {
            direction = hit.point - transform.position;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            direction.y = 0f;
            GameObject pastryshot = Instantiate(pastry, transform.position, transform.rotation);
            pastryshot.GetComponent<Rigidbody>().AddRelativeForce(direction * launchVelocity);
        }
    }

}