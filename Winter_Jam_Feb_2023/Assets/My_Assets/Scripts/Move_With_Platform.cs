using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_With_Platform : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(transform);
        }
    }

    void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player"){
            collision.gameObject.transform.SetParent(null);
        }
    }
}
