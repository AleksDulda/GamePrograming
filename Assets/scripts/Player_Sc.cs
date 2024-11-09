using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sc : MonoBehaviour
{

    public int Health = 3;
    public float speed; //hareket süresi
    public Transform firePoint; // Lazerin çýkýþ noktasý (namlu)
    public GameObject laser; //Lazer objesi
    public GameObject TripleLaser;
    [SerializeField]
    private float firecooldown = 5f, Normalcooldown; // Bir sonraki atýþ için bekleme süresi
    private Boolean vur = true; // vur emri var mý yok mu

    public GameObject LazerCon;

    [SerializeField]
    bool TripleShotActive = false;
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
            if (TripleShotActive)
            {
                Instantiate(TripleLaser, firePoint.position, Quaternion.identity).transform.parent = LazerCon.transform;
                
            }
            else
            {
                Instantiate(laser, firePoint.position, Quaternion.identity).transform.parent = LazerCon.transform;
            }
           
            
            firecooldown = Normalcooldown;
        }

    }
    public float xVal = 8.3f, yVal = 4.35f;
    void Movment()
    {


        transform.Translate(new Vector3(Input.GetAxis("Horizontal") * speed* Time.deltaTime, Input.GetAxis("Vertical") * speed* Time.deltaTime, 0));// oluþturduðumuz kübün hareket mekanýzmasý 
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

  

    public void ActivateTripleShot()
    {
        TripleShotActive = true;  // Activate Triple Shot

        //  5sn beklemesi için coroutine baþlat
        StartCoroutine(DeactivateTripleShotAfterDelay(5f));
    }

    private IEnumerator DeactivateTripleShotAfterDelay(float delay)
    {
        // belirtilen süre kadar bekle
        yield return new WaitForSeconds(delay);

        // Deactivate Triple Shot
        TripleShotActive = false;
    }

}
