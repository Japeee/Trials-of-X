using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform spawnPos;
    public int maxHealth = 100;
    public int currentHealth;
    private Animator anim;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;

    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    void Update()
    {
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            anim.SetTrigger("Death");
            speed = 0f;
            maxRange = 0f;
            minRange = 0f;
            anim.SetBool("isMoving", false);
            Destroy(gameObject, 1.5f);
        }
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }
        
    }
    public void FollowPlayer()
    {
        anim.SetBool("isMoving", true);
        anim.SetFloat("moveX", (target.position.x - transform.position.x));
        anim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoHome()
    {
        anim.SetFloat("moveX", (spawnPos.position.x - transform.position.x));
        anim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, spawnPos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, spawnPos.position) == 0)
        {
            anim.SetBool("isMoving", false);
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.gameObject.CompareTag("Staff"))
        {
            Debug.Log("Took damage");
            currentHealth -= 50;
        }
    }
    public void TakeDamage (int dmg)
    {
        dmg -= currentHealth;
    }
}
