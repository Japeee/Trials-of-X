using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportManager : MonoBehaviour
{
    
    public string sceneToLoad;
    public GameObject player, playerSpawnPos;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
            player.transform.position = playerSpawnPos.transform.position;
        }       
    }

}
