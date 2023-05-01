using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed = 10f;
    public float actualSpeed;

    private Transform target;

    private int wavePoint = 0;
    
    public float startHealth = 100;
    private float health;

    public int worth = 50;

    private bool isDead = false;
    private int id;

    public bool isSlow = false;
    public bool isOnFire = false;

    void Start()
    {
        id = Random.Range(0, 2000);
        actualSpeed = startSpeed;
        health = startHealth;
        target = Waypoints.Waypoint[0];
    }

    void Update()
    {
        Renderer r = GetComponent<Renderer>();
        if(isSlow && isOnFire)
        {
            r.material.color = Color.magenta;        
        }else if(isSlow)
        {
            r.material.color = Color.cyan;
        }
        else if (isOnFire)
        {
            r.material.color = Color.red;
        }
        else
        {
            r.material.color = Color.white;
        }
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * actualSpeed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.2f)
        {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint()
    {
        if (wavePoint >= Waypoints.Waypoint.Length - 1)
        {
            EndPath();
            return;
        }
        wavePoint++;
        target = Waypoints.Waypoint[wavePoint];
    }

    void EndPath()
    {
        //TAKE HEALTH FROM PLAYER
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        //print(id + " " + health);
        if(health<=0 && !isDead)
        {
            Die();
        }
    }

    void Die()
    {
        isDead=true;
        //give player money
        
        Destroy(gameObject);
    }
}
