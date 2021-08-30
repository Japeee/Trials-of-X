using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawnBack : MonoBehaviour
{
    public GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Object.DontDestroyOnLoad(player);
        player.transform.position = new Vector2(50.5f, 28f);
        SceneManager.LoadScene("Trials");
    }
}
