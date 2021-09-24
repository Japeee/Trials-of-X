using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffController : MonoBehaviour
{
    public GameObject staff;
    public GameObject crystal;
    public float speed;
    public Transform offset;
    public EdgeCollider2D col;
    private Animator animator;

    private void Start()
    {
        staff = GameObject.FindGameObjectWithTag("Staff");
        crystal.transform.position = staff.transform.position;
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Vector2 dir = Vector2.zero;
        if (Input.GetKey(KeyCode.A))
        {
            dir.x = -1;
            animator.SetInteger("Direction", 3);
            crystal.transform.position = staff.transform.position;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir.x = 1;
            animator.SetInteger("Direction", 2);
            crystal.transform.position = new Vector3(staff.transform.position.x + 0.55f, staff.transform.position.y - 0.03f, staff.transform.position.z);
        }

        if (Input.GetKey(KeyCode.W))
        {
            dir.y = 1;
            animator.SetInteger("Direction", 1);
            crystal.transform.position = staff.transform.position;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            dir.y = -1;
            animator.SetInteger("Direction", 0);
            crystal.transform.position = staff.transform.position;
        }

        dir.Normalize();
        //animator.SetBool("IsMoving", dir.magnitude > 0);
    }

}

