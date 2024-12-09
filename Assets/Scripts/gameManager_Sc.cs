using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager_Sc : MonoBehaviour
{
    // Start is called before the first frame update
    bool isGameOver = false;
    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && isGameOver)
        {
            SceneManager.LoadScene(0);
        }
    }
    public void GameOver()
    {
        isGameOver = true;
    }
    public void YeniOyunBaslat()
    {
        SceneManager.LoadScene(0); 
    }
}
