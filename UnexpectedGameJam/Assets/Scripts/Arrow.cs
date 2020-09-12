using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{

    public float movementSpeed;

    void Awake()
    {
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerMovement>().Damage();
        }
    }
}
