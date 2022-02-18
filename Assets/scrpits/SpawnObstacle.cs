using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject[] prefabs;

   
    public float startDelay = 2f;
    public float repeatRate = 2f;

    private PlayerController playerControllerScript;

    private int randomIndex;


    private Quaternion offset = Quaternion.Euler(0, 100, 0);


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnRandomObject", startDelay, repeatRate);

        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
  
    private void spawnRandomObject()
    {

        float randomSide = Random.Range(0, 2);

        randomIndex = Random.Range(0, prefabs.Length);

        if (randomSide == 0)
        {
            float yRange = Random.Range(1f, 14f);
            float xRange = 16f;
            Quaternion giro180 = Quaternion.Euler(0, 180, 0);

            Vector3 spawnPos = new Vector3(xRange, yRange, 0);
            Instantiate(prefabs[randomIndex], spawnPos, giro180);// drch
        }
        else
        {
            float yRange = Random.Range(1f, 14f);
            float xRange = 16f;

            Vector3 spawnPos = new Vector3(-xRange, yRange, 0);
            Instantiate(prefabs[randomIndex], spawnPos, prefabs[randomIndex].transform.rotation);//izq
        }

        if (playerControllerScript.gameOver)//para el spawn
        {
            CancelInvoke();
        }
    }
    
  
}
