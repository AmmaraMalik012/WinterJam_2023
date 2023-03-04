using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    public Transform respawnPoint;
    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            print("Dead");
            KillPlayer(collision.gameObject);

            // Respawn();
        }
    }

    void KillPlayer(GameObject player) {
        // Add any additional logic here for killing the player
        // Destroy(player);
        player.transform.position = respawnPoint.position; // move the player to the respawn point
    }

    // void Respawn() {
    //     other.transform.position = respawnPoint.position; // move the player to the respawn point
    // }
}
