using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Close : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool isOpened = true;
    void OnCollisionEnter2D(Collision2D collision){
        // transform.position -= new Vector3 (0, .2f, 0);
        if (collision.gameObject.tag == "Player" && isOpened){
            isOpened = false;
            door.transform.position -= new Vector3 (0, 5, 0);
        }
    }
}
