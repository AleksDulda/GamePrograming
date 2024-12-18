using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astreoid_SC : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;

    [SerializeField]
    private float rotatespeed = 20.0f;

    [SerializeField]
    private Player_Sc player; // Kalýtým alýndý

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player_Sc>();

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
        transform.Rotate(Vector3.forward * rotatespeed * Time.deltaTime);
        transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);

        if (transform.position.y < -5.4f)
        {
            float randomX = Random.Range(-player.xVal, player.xVal);
            transform.position = new Vector3(randomX, player.yVal + 1, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D other) // temasa giren
    {
        if (other.tag == "Player")
        {
            if (player.isShieldActive)
            {
                player.isShieldActive = false;
            }
            else
            {
                player.Damage();
            }

            anim.SetTrigger("IsTouch");
            speed = 0;
            Destroy(gameObject, 1.0f); // enemy'i yok et
        }
        else if (other.tag == "Lazer")
        {
            Destroy(other.gameObject); // lazeri yok et
            anim.SetTrigger("IsTouch");
            speed = 0;
            Destroy(gameObject, 1.0f); // enemy'i yok et
            player.score += 10;
        }
    }
}
