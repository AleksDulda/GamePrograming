using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy_Sc : MonoBehaviour
{
    [SerializeField]
    public float speed=3f; //hareket süresi
    [SerializeField]
    private Player_Sc player; //Kalýtým alýndý

    Animator anim;

   
    void Start()
    {
        player=GameObject.FindObjectOfType<Player_Sc>();
        if (player == null)
        {
            Debug.LogError("Player not found!");
        }
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            Debug.LogError("Animator not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if(transform.position.y < -5.4f)
        {
            float randomX = Random.Range(-player.xVal, player.xVal);
            transform.position = new Vector3(randomX, (player.yVal+1), 0);
        }
        
        
    }
    void OnTriggerEnter2D (Collider2D other) //temasa giren
    {
        if(other.tag == "Player")
        {
            if (player.isShieldActive)
            {
                player.isShieldActive = false;
                
                anim.SetTrigger("OnEnemyDeath");
                speed = 0;
                Destroy(gameObject,1.0f);// enemyi yok et
            }
            else{
                player.Damage();
                anim.SetTrigger("OnEnemyDeath");
                speed = 0;
                Destroy(gameObject,1.0f);// enemyi yok et
            }
        }
        else if(other.tag == "Lazer")
        {
            
            Destroy(other.gameObject);//lazeri yok et
            anim.SetTrigger("OnEnemyDeath");
            speed = 0;
            
            Destroy(gameObject, 1.0f);// enemyi yok et
            player.score += 10;

        }
    }
}

