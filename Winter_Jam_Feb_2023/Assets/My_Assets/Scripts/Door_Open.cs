using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool isOpened = false;
    void OnCollisionEnter2D(Collision2D collision){
        // transform.position -= new Vector3 (0, .2f, 0);
        if (collision.gameObject.tag == "Player" && !isOpened){
            isOpened = true;
            door.transform.position += new Vector3 (0, 5, 0);
        }
    }

    // void OnCollisionExit2D(Collision2D collision){
    //     // transform.position += new Vector3 (0, .2f, 0);
    //     door.transform.position -= new Vector3 (0, 5, 0);
    // }
}
