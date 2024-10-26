using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sc : MonoBehaviour
{
    
    public int Health = 3;
    public float speed; //hareket s�resi
    public Transform firePoint; // Lazerin ��k�� noktas� (namlu)
    public GameObject laser; //Lazer objesi
    [SerializeField]
    private float firecooldown=5f , Normalcooldown; // Bir sonraki at�� i�in bekleme s�resi
    private Boolean vur=true; // vur emri var m� yok mu
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
        Ateset(); //ates etme fonksiyonu
        if(firecooldown <= Normalcooldown && firecooldown > 0) 
        {
            firecooldown -= Time.deltaTime;
            vur = false;
        }
        else
        {
            vur = true;
        }
    }

    private void Ateset()
    {
        if (Input.GetKey(KeyCode.Space) && vur)
        {
            Instantiate(laser, firePoint.position, Quaternion.identity);
            firecooldown = Normalcooldown;
        }

    }
    public float xVal = 8.3f, yVal = 4.35f;
    void Movment()
    {


        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed* Time.deltaTime, Input.GetAxis("Vertical") * speed* Time.deltaTime, 0));// olu�turdu�umuz k�b�n hareket mekan�zmas� 
        transform.position = new Vector3 (Mathf.Clamp(transform.position.x, -xVal, xVal), Mathf.Clamp(transform.position.y, -yVal, yVal),0);

      
    }

    public void Damage()
    {
        Health--;
        if (Health <= 0)
        {
            Debug.Log("GAME OVER");
            Destroy(gameObject);
            
        }

    }
}
