using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bonus_Sc : MonoBehaviour
{
    private Player_Sc player;
    float speed = 3;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player_Sc>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        if (player.Health <= 0 || this.transform.position.y<-6f)
        {
            Destroy(this.gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            player.ActivateTripleShot();
            Destroy(this.gameObject );
        }
    }
}
