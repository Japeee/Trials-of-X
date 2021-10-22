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
    public bool updateDir = true;
    public bool canAttack = true;
    public enum CardinalDirections { NORTH, SOUTH, EAST, WEST };
    public CardinalDirections playerFacing;

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
        updatePlayerDir(movement);
        movement = movement.normalized;
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetMouseButtonDown(1) && canAttack == true)
        {
            animator.SetTrigger("Attack");
            canAttack = false;
            StartCoroutine(waitToAttack());
        }

        if(playerFacing == CardinalDirections.EAST)
        {
            crystal.transform.position = new Vector3(staff.transform.position.x + 0.59f, staff.transform.position.y - 0.03f, staff.transform.position.z);
        }
        else
        {
            crystal.transform.position = staff.transform.position;
        }
    }
    void updatePlayerDir(Vector2 incomingMove)
    {
        //EAST WEST
        if (updateDir)
        {
            //West
            if (incomingMove.x == -1f && incomingMove.y > -0.2 && incomingMove.y < 0.2f)
                playerFacing = CardinalDirections.WEST;
            else if (incomingMove.x == 1f && incomingMove.y > -0.2 && incomingMove.y < 0.2f)
                playerFacing = CardinalDirections.EAST;
        }
        //North South
        if (updateDir)
        {
            //North
            if (incomingMove.x > -0.2f && incomingMove.x < 0.2f && incomingMove.y == 1f)
                playerFacing = CardinalDirections.NORTH;
            else if (incomingMove.x > -0.2f && incomingMove.x < 0.2f && incomingMove.y == -1f)
                playerFacing = CardinalDirections.SOUTH;
        }

        animator.SetInteger("Direction", (int)playerFacing);
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
    IEnumerator waitToAttack()
    {

        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }

}

