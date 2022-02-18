using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleControllerr : MonoBehaviour
{
    public float HorizontalSpeed = 5f;

    private float xLim = 17f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //se mueve en el eje horizontal
        transform.Translate(Vector3.right * HorizontalSpeed * Time.deltaTime);
       
        
        
        if (transform.position.x > xLim && gameObject.CompareTag("Obstacle" ) || transform.position.x < -xLim)// sale de los limites y desaparece
        {
            Destroy(gameObject);
            Debug.Log("desaparece");
        }
        if (transform.position.x > xLim && gameObject.CompareTag("Money") || transform.position.x < -xLim)// sale de los limites y desaparece
        {
            Destroy(gameObject);
            Debug.Log("desaparece");
        }
    }
}
