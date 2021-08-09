using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public Action onEnemyDestroyed;
    public Action onWrongEnemy;
    private void Start()
    {
        int randomEnemy = Random.Range(0, 2);
        if (randomEnemy == 0)
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        }
        else
        {
            this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BulletController>() != null)

        {
            if (collision.gameObject.GetComponent<Renderer>().material.GetColor("_Color") == this.gameObject.GetComponent<Renderer>().material.GetColor("_Color"))
            {
                Destroy(gameObject);
                OnEnemyDestroyed();
            }
            
            else
            {
                onWrongEnemy();
            }
        }
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            if(collision.gameObject.GetComponent<PlayerController>().weapon.GetComponentInChildren<Renderer>().material.GetColor("_Color")==
                    this.GetComponent<Renderer>().material.GetColor("_Color"))
            {
                onWrongEnemy();
            }
            else
            {
                Destroy(gameObject);
                onEnemyDestroyed();
            }
        }


    }

    public void OnEnemyDestroyed()
    {
        Debug.Log("enemy destroyed");
    }
}
