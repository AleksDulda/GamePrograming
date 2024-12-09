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
   
    void Start()
    {
        player=GameObject.FindObjectOfType<Player_Sc>();
        
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
                Destroy(gameObject);
            }
            else{
                player.Damage();
                Destroy(gameObject);//player'i yok et
            }
        }
        else if(other.tag == "Lazer")
        {
            
            Destroy(other.gameObject);//lazeri yok et
            Destroy(gameObject);// enemyi yok et
            player.score += 10;
            


        }
    }
}

