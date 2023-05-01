using UnityEngine;

public class Grill : MonoBehaviour
{
    public float activationRadius = 10f;
    public float damageAmount = 0.4f;

    public void Update()
    {
        GameObject[] allEnemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject E in allEnemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, E.transform.position);
            
            Enemy enemy = E.GetComponent<Enemy>();
            Renderer enemyrenderer = E.GetComponent<Renderer>();

            Color c = enemyrenderer.material.color;

            if (distanceToEnemy <= activationRadius)
            {
                print("red");
                //enemyrenderer.material.color = Color.red;
                enemy.TakeDamage(damageAmount);
                enemy.isOnFire = true;
            }
            else{
                //enemyrenderer.material.color = Color.white;
                enemy.isOnFire = false;
            }
        }
    }
}
