using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Mermi : MonoBehaviour
{
    
   
    public float laserSpeed = 10f; //Lazerin gidiþ hýzý
    
    [SerializeField]
    private float destroytimeformermi = 5; //Lazerin hayatta kalma süresi

    void Update()
    {
        transform.position = transform.position + new Vector3(0, laserSpeed * Time.deltaTime, 0); // Lazer atýldýktan sonra 'y' ekseninde hareket etmesi
        Destroy(gameObject,destroytimeformermi); // oluþturulan lazerin belirli bir süre sonra yok edilmesi
    }

   
    
}