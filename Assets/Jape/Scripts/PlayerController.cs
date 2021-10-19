using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	public Animator animator;
	public bool updateDir = true;
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
		if (updateDir)
		{
			//West
			if (incomingMove.x == -1f && incomingMove.y > -0.2 && incomingMove.y < 0.2f)
				playerFacing = CardinalDirections.WEST;
			else if(incomingMove.x == 1f && incomingMove.y > -0.2 && incomingMove.y < 0.2f)
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
}

