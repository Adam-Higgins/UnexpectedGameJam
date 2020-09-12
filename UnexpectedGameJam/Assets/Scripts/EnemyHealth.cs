using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currHealth;
    private HealthBar healthBar;

    void Awake()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        healthBar.SetMaxHealth(maxHealth);
    }
    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void LoseHealth(int dmg)
    {
        Debug.Log("Yo");
        currHealth -= dmg;
        healthBar.SetHealth(currHealth);
        if (currHealth < 1)
            Destroy(gameObject);
    }
}
