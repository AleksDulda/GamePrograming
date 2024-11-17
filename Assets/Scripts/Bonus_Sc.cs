using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public class Bonus_Sc : MonoBehaviour
{
    private Player_Sc player;
    float speed = 3;

    [SerializeField]
    int BonusId;


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

            switch (BonusId)
            {
                case 0:
                    player.ActivateTripleShot();
                    Destroy(this.gameObject);
                    Debug.Log("Bonus Üçlü atýþ");
                    break;

                case 1:
                    player.ActivateSpeedBonus();
                    Debug.Log("Bonus hýz");
                    Destroy(this.gameObject);
                    break;

                case 2:
                    Debug.Log("Bonus koruma");
                    Destroy(this.gameObject);
                    break;

                default:
                    Debug.Log("Tanýmlanmamýþ Bonus");
                    break;
            }

        }
    }
}
