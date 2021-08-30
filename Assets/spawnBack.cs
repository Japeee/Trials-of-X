using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawnBack : MonoBehaviour
{
    public GameObject player;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        player.transform.position = new Vector2(50.5f, 28f);
    }
}
