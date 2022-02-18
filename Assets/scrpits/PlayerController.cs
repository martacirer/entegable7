using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool gameOver;

    private float FuerzaImpulso = 15f;
    private float yLimite = 14f;

    private AudioSource playerAudioSource;

    public AudioClip jumpClip;
    public AudioClip crashClip;
    public AudioClip moneyClip;

    public ParticleSystem explosionParticleSystem;
    public ParticleSystem moneyParticleSystem;

    private Rigidbody playerRigidbody;

    private int TotalMonedas = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        playerRigidbody = GameObject.Find("Player").GetComponent<Rigidbody>();// el player tiene en cuenta el rigidbody para los choques
        Debug.Log(TotalMonedas);
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))//tecla espacio
            {
                playerRigidbody.AddForce(Vector3.up * FuerzaImpulso, ForceMode.Impulse);//impulso
            }
            if (transform.position.y > yLimite)
            {
                transform.position = new Vector3(transform.position.x, yLimite, transform.position.z);
                playerRigidbody.velocity = Vector3.zero; // barerras invisibles 
            }
        }
      
    }
    private void OnCollisionEnter(Collision othercollider)
    {
        if (!gameOver)
        {
            if(othercollider.gameObject.CompareTag("Ground"))// si el player toca el suelo gameOver
            {
                gameOver = true;
                Debug.Log("GAME OVER");
                Time.timeScale = 0;
                
            }
            if (othercollider.gameObject.CompareTag("Obstacle"))// si el player toca un obstaculo gameOver
            {
                gameOver = true;
                Debug.Log("GAME OVER");
                Destroy(othercollider.gameObject);

                Instantiate(explosionParticleSystem,
                    transform.position,
                explosionParticleSystem.transform.rotation);// particulas

                explosionParticleSystem.Play();

                //Time.timeScale = 0;
            }
        }
    }
    private void OnTriggerEnter(Collider otherCollider)
    {
        TotalMonedas += 1;
        Destroy(otherCollider.gameObject);
        Debug.Log($"Tienes {TotalMonedas} monedas");// si tocas una moneda suma uno al recuento y desaparece

              
        Instantiate(moneyParticleSystem,
                   transform.position,
               moneyParticleSystem.transform.rotation);// particulas

        moneyParticleSystem.Play();
        
    }



}
