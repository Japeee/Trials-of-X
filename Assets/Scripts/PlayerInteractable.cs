using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    Interactable radius; 


    void Start()
    {
         = GetComponent<Interactable>();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(1) && radius < 3f)
        {
           
        }
    }
}
