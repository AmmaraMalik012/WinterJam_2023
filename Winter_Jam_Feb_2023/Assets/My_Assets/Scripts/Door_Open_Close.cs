using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Open_Close : MonoBehaviour
{
    [SerializeField] GameObject door;
    bool isOpened = false;
    void OnTriggerEnter2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Stone" && !isOpened){
            print("Enter");
            isOpened = true;
            door.transform.position += new Vector3 (0, 5, 0);
        }
        // else if (collision.gameObject.tag == "Stone" && !isOpened){
        //     print("Enter");
        //     isOpened = true;
        //     door.transform.position += new Vector3 (0, 5, 0);
        // }
    }

    void OnTriggerExit2D(Collider2D collision){
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Stone" && isOpened){
            print("Exit");
            isOpened = false;
            door.transform.position -= new Vector3 (0, 5, 0);
        }
        // else if (collision.gameObject.tag == "Player" && isOpened){
        //     print("Exit");
        //     isOpened = false;
        //     door.transform.position -= new Vector3 (0, 5, 0);
        // }
    }
}
