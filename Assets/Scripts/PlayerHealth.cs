using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] float forceDeath;
    [SerializeField] float deathTime;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        GameManager.Instance.Initialize(maxHealth);
    }

    public void TakeDamage(float damage) {
        if (anim.GetBool("hurt")) {
            return;
        }
        GameManager.Instance.ChangeHealth(-damage);
        anim.SetBool("hurt", true);
        Invoke("HurtToFalse", 1);
        if (GameManager.health <= 0)
        {
            Death();
        }
    }

    void HurtToFalse() {
        anim.SetBool("hurt", false);
    }

    void Restart() { 
    GameManager.Instance.Restart();
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void Death() { 
        GetComponent<CapsuleCollider2D>().enabled = false;
        GetComponent<Rigidbody2D>().AddForce(Vector2.up*forceDeath);
        Invoke("Restart", deathTime);
    
    }
}
