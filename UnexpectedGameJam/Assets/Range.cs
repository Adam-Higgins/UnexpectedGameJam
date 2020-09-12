using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Range : MonoBehaviour
{

    public Animator EnemyAnimator;
    public float delay;
    public GameObject Demon;
    public GameObject target;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            EnemyAnimator.SetBool("Range", true);
            GetComponent<NavMeshAgent>().speed = 0;
            StartCoroutine(Delay());
        }

        IEnumerator Delay()
    {
            yield return new WaitForSeconds(delay);
            EnemyAnimator.SetBool("Range", false);
            Demon.transform.LookAt(target.transform);
            GetComponent<NavMeshAgent>().speed = 4;
        }
    }
}
