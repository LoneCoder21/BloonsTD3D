using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
   public Transform enmemyPre;
   public Transform spawnPoint;


    public static int EnemiesAlive = 0;
   public float timeBetweenWaves = 30f;
    private float countDown = 1f;
    public Text waveCountdownText;
    private int waveNum = 2;
   

   void Update()
   {
     if (EnemiesAlive > 0)
		{
			return;
		}

        if(countDown<=0)
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;
        }
        countDown -= Time.deltaTime;
      countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
	waveCountdownText.text = string.Format("{0:00.00}", countDown);
     
   }

   IEnumerator SpawnWave()
   {
       waveNum=waveNum*waveNum;
        for(int i =0; i< waveNum; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(0.45f);
        }
        
        timeBetweenWaves+=3;
   }


   void SpawnEnemy ()
	{
		Instantiate(enmemyPre, spawnPoint.position, spawnPoint.rotation);
	}
}
