using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class flyMovement : MonoBehaviour
{
    [Header("Points")]
    [SerializeField] Transform[] pointObjects;
    [SerializeField] GameObject player;
    Vector2[] points;

    Vector3 posToGo;
    int iPoint;
    [Header("Parameters")]
    [SerializeField] float speed;
    [SerializeField] float sightDistance;
    [SerializeField] float damage;

    // Start is called before the first frame update
    void Start()
    {
        iPoint = 0;
        points=new Vector2[pointObjects.Length];
        for (int i = 0; i < pointObjects.Length; i++)
        {
            points[i]=pointObjects[i].position;
        
        }
        posToGo = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, posToGo, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, player.transform.position) <= sightDistance) {
            Chase();
        }
        else { 
            Patrol();
        }
    }

    void Patrol() {
        if (transform.position == posToGo) { 
            iPoint=(iPoint+1)%points.Length;
            posToGo=points[iPoint];
        }
    }

    void Chase() { 
    posToGo=player.transform.position;
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
