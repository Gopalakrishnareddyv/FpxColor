using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float bulletSpeed;
    public GameObject bullet;
    public GameObject weapon;
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        weapon.GetComponent<Renderer>().material.SetColor("_Color",Color.red);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GameObject bulletobj = Instantiate(bullet);
            bulletobj.transform.position = point.transform.position + point.transform.forward + this.transform.up * 1.0f;
            bulletobj.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);
            bulletobj.GetComponent<Renderer>().material.SetColor("_Color", weapon.GetComponent<Renderer>().material.GetColor("_Color"));

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>() != null)
        {
            
            
        }
    }


}