using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    public Action onEnemyDestroyed;
    public Action onWrongEnemy;
    public float timeChange;
    float temp;
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
        temp = timeChange;
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
    private void Update()
    {
        timeChange -= Time.deltaTime;
        if (timeChange <temp/2f)
        {
            //Debug.Log(this.GetComponent<Renderer>().material.GetColor("_Color") == Color.red);
            if (this.GetComponent<Renderer>().material.GetColor("_Color") == Color.red)
            {
                this.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            }
            timeChange -= Time.deltaTime;

            if (timeChange < 0f)
            {
                //Debug.Log(this.GetComponent<Renderer>().material.GetColor("_Color") == Color.red);
                if (this.GetComponent<Renderer>().material.GetColor("_Color") == Color.blue)
                {
                    this.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                }
                timeChange = temp;
            }

        }
       
    }
}
