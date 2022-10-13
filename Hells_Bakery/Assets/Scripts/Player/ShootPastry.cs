using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPastry : MonoBehaviour
{
    public GameObject pastry;
    public float launchVelocity = 1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject pastryshot = Instantiate(pastry, transform.position, transform.rotation);
            pastryshot.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, launchVelocity));
        }
    }

}