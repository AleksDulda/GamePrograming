using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;





public class UI_Manager_Sc : MonoBehaviour
{
    private gameManager_Sc gameManager;

    [SerializeField]
    private TextMeshProUGUI scoreText;

    [SerializeField]
    private TextMeshProUGUI gameoverTMP;

    [SerializeField]
    private TextMeshProUGUI restartTMP;

    [SerializeField]
    private Image livesImage;

    [SerializeField]
    private Sprite[] livesSprites;


    private void Awake()
    {
        gameManager = GameObject.FindObjectOfType<gameManager_Sc>();
        if (gameManager == null)
        {
            Debug.LogError("GameManager not found!");
            return;
        }
    }
    private void Start()
    {
        

        if (scoreText == null)
        {
            Debug.LogError("ScoreText not assigned!");
            return;
        }

        if (livesImage == null)
        {
            Debug.LogError("LivesImage not assigned!");
            return;
        }

        if (gameoverTMP == null)
        {
            Debug.LogError("GameOverTMP not assigned!");
            return;
        }

        if (restartTMP == null)
        {
            Debug.LogError("RestartTMP not assigned!");
            return;
        }

        if (livesSprites == null || livesSprites.Length == 0)
        {
            Debug.LogError("LivesSprites not assigned or empty!");
            return;
        }

        scoreText.text = "Score: 0";
        livesImage.sprite = livesSprites[3];
        gameoverTMP.gameObject.SetActive(false);
        restartTMP.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int currentLives)
    {
        livesImage.sprite = livesSprites[currentLives];

        if (currentLives == 0)
        {
            GameOverSequance();
        }
    }

    public void GameOverSequance()
    {
        gameoverTMP.gameObject.SetActive(true);
        restartTMP.gameObject.SetActive(true);
        StartCoroutine(GameOverFlicker());
        gameManager.GameOver();
    }

    private IEnumerator GameOverFlicker()
    {
        while (true)
        {
            gameoverTMP.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            gameoverTMP.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
