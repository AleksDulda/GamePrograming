using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float speed; //hareket süresi
    public Transform firePoint; // Lazerin çýkýþ noktasý (namlu)
    public GameObject laser; //Lazer objesi
    [SerializeField]
    private float firecooldown=5f , Normalcooldown; // Bir sonraki atýþ için bekleme süresi
    private Boolean vur=true; // vur emri var mý yok mu

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0));// oluþturduðumuz kübün hareket mekanýzmasý
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

}
