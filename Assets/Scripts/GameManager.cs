using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int score = 0;
    public static GameManager instance;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject coinPrefab;

    [SerializeField]
    List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private GameObject winGameUI;
    [SerializeField]
    private GameObject loseGameUI;
    [SerializeField]
    private TextMeshProUGUI playerHealthText;

    private void Awake()
    {
        if (instance != this && instance != null)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkScore();
        playerHealthText.text = "Health: " + Player.instance.health;
        //allow restart and quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            restartScene();
        }
    }

    public void restartScene()
    {
        SceneManager.LoadScene(0);
    }


    public void addPoint()
    {
        score++;
        scoreText.text = "Coins: " + score;
        StartCoroutine(spawnRoutine());
    }

    private void checkScore()
    {
        if (score > 2)
        {
            winGameUI.SetActive(true);
        }
    }

    public void playerDied()
    {
        loseGameUI.SetActive(true);
    }

    private IEnumerator spawnRoutine()
    {
        yield return new WaitForSeconds(1f);
        int rPos = Random.Range(0, spawnPoints.Count - 1);
        Debug.Log(rPos);
        Instantiate(coinPrefab, spawnPoints[rPos]);
    }
}
