using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalManager : MonoBehaviour
{
    public GameObject player, portal;
    public GameObject boundaries;

    public void OnTriggerEnter2D(Collider2D other)
    {            
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(Portal());
        }        
    }

    IEnumerator Portal()
    {
        yield return new WaitForSeconds(0.5f);
        player.transform.position = new Vector2(portal.transform.position.x, portal.transform.position.y);
    }

   
}
