using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    int currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage){
        animator.SetTrigger("Hit");
        currentHealth -= damage;
        if(currentHealth <= 0){
            Die();
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);
        Debug.Log("DIE!!!");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
    }
}
