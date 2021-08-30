using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Object.DontDestroyOnLoad(player);
        player.transform.position = new Vector2(0, 0);
        SceneManager.LoadScene("BlackForest");
    }
}
