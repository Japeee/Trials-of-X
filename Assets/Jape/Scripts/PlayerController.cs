using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	public Animator animator;
	public bool safeToUpdateDir = true;
	public enum CardinalDirections { NORTH, SOUTH, EAST, WEST };
	public CardinalDirections playerFacing;



	Vector2 movement;

	private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		updatePlayerDir(movement);
		movement = movement.normalized;
		//animator.SetFloat("Horizontal", movement.x);
		//animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Speed", movement.sqrMagnitude);

		if (Input.GetMouseButtonDown(1))
		{
			animator.SetTrigger("Attack");
		}
	}
	void updatePlayerDir(Vector2 incomingMove)
	{
		//EAST WEST
		if (safeToUpdateDir)
		{
			//West
			if (incomingMove.x == -1f && incomingMove.y > -0.2 && incomingMove.y < 0.2f)
				playerFacing = CardinalDirections.WEST;
			if(incomingMove.x == 1f && incomingMove.y > -0.2 && incomingMove.y < 0.2f)
				playerFacing = CardinalDirections.EAST;
		}
		//North South
		else
		{
			//North
			if (incomingMove.x > -0.2f && incomingMove.x < 0.2f && incomingMove.y == 1f)
				playerFacing = CardinalDirections.NORTH;
			if (incomingMove.x > -0.2f && incomingMove.x < 0.2f && incomingMove.y == -1f)
				playerFacing = CardinalDirections.SOUTH;
		}
		//your animator will need a new int to store current direction
		//The nice thing about enums is they act as int so your animator will understand
		//Direction as 0 - North, 1- South, 2-East, 3- West
		
		animator.SetInteger("Direction", (int)playerFacing);
		safeToUpdateDir = false;
		StartCoroutine(resetDirCooldown());
		//With this you could actually get rid of the hor and vert your transition cases will say something like
		//If speed > 0 and direction = 0 then animate walk facing north
		//When falling out the if speed < 0 should go back to an empty animator with the 4 directional idles in it
		//The empty idle animation should transition to one of the directional idles based of the direction float.
	}
		private void FixedUpdate()
		{
			rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		}
	IEnumerator resetDirCooldown()
	{
		yield return new WaitForSeconds(0.1f);
		safeToUpdateDir = true;
	}
}

