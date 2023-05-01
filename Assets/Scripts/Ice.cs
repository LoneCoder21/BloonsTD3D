using System.Collections.Generic;
using UnityEngine;

public class Ice : MonoBehaviour
{
    public float activationRadius = 10f;
    public float slowDownFactor = 0.5f;

    public void Start()
    {
    }

    public void Update()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemy");
        bool apply = false;
        foreach (GameObject E in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, E.transform.position);
            
            Enemy enemy = E.GetComponent<Enemy>();
            Renderer enemyrenderer = E.GetComponent<Renderer>();

            Color c = enemyrenderer.material.color;

            if (distanceToEnemy <= activationRadius)
            {
                apply = true;
                float distanceFactor = 1 - (distanceToEnemy / activationRadius);
                float currentSlowDownFactor = slowDownFactor * distanceFactor;

                enemy.actualSpeed = enemy.startSpeed * slowDownFactor;
                //enemyrenderer.material.color = Color.blue;
                enemy.isSlow = true;
            }
            else
            {
                enemy.actualSpeed = enemy.startSpeed;
                //enemyrenderer.material.color = Color.white;
                enemy.isSlow = false;
            }
        }
    }
}
