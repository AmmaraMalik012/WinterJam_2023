using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_Body : MonoBehaviour
{
    public GameObject objectToSpawn;
    public Vector3 spawnPosition;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("Hit");
            other.GetComponent<Player_Controller>().enabled = false;
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }
}
