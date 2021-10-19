using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour
{
    public GameObject staff;
    public GameObject crystal;
    public float moveSpeed;
    public Transform offset;
    private Animator animator;
    public Rigidbody2D rb;

    Vector2 movement;

    private void Start()
    {
        staff = GameObject.FindGameObjectWithTag("Staff");
        crystal.transform.position = staff.transform.position;
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }

        if(movement.x > 0.99f)
        {
            crystal.transform.position = new Vector3(staff.transform.position.x + 0.59f, staff.transform.position.y - 0.03f, staff.transform.position.z);
        }
        else
        {
            crystal.transform.position = staff.transform.position;
        }
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

}

