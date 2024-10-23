using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class Mermi : MonoBehaviour
{
    
   
    public float laserSpeed = 10f; //Lazerin gidi� h�z�
    
    [SerializeField]
    private float destroytimeformermi = 5; //Lazerin hayatta kalma s�resi

    void Update()
    {
        transform.position = transform.position + new Vector3(0, laserSpeed * Time.deltaTime, 0); // Lazer at�ld�ktan sonra 'y' ekseninde hareket etmesi
        Destroy(gameObject,destroytimeformermi); // olu�turulan lazerin belirli bir s�re sonra yok edilmesi
    }

   
    
}