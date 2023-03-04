using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Btn_Fell_Spike : MonoBehaviour
{
    public GameObject objectToEnableDisable;
    private Rigidbody2D rb;

    void Start()
    {
        rb = objectToEnableDisable.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            rb.isKinematic = false; // disable kinematic to allow gravity to affect the object
        }
    }
}
