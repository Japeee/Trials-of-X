using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	PlayerHealthScript hpScript;
	public float moveSpeed = 5f;
	public Rigidbody2D rb;
	public Animator animator;
	public bool updateDir = true;
	public bool canAttack = true;
	public bool isAttacking = false;
	public enum CardinalDirections { NORTH, SOUTH, EAST, WEST };
	public CardinalDirections playerFacing;



	Vector2 movement;


    private void Start()
    {
		hpScript = GetComponent<PlayerHealthScript>();
    }
    private void Update()
	{
		movement.x = Input.GetAxisRaw("Horizontal");
		movement.y = Input.GetAxisRaw("Vertical");
		updatePlayerDir(movement);
		movement = movement.normalized;
		animator.SetFloat("Speed", movement.sqrMagnitude);
		if (Input.GetMouseButtonDown(1) && canAttack == true && isAttacking == false)
		{
			animator.SetTrigger("Attack");
			isAttacking = true;
			//movement.x = 0f;
			//movement.y = 0f;
			canAttack = false;
			StartCoroutine(waitToAttack());
		}
		if(hpScript.currentHealth <= 0)
        {
			moveSpeed = 0f;
			animator.SetTrigger("Death");
			foreach (Transform child in transform)
			{
				Destroy(child.gameObject);
			}
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
			if(isAttacking == false)
        {
			rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
		}
			
		}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider.gameObject.CompareTag("Enemy"))
		{
			hpScript.TakeDamage(5);
		}
	}
	IEnumerator waitToAttack()
    {

		yield return new WaitForSeconds(0.5f);
		canAttack = true;
		isAttacking = false;
    }
}

