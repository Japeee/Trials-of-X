using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;

    private float horizontalInput;
    private float verticalInput;


    private void Update()
    {              
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");          
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement.Normalize();
        GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;        
    }
}
