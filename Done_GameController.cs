using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class Done_GameController : MonoBehaviour
{
    public GameObject[] hazards;
    public Vector3 spawnValues;
    public float hazardCount = 5f;
    public float spawnWait = .75f;
    public float startWait = 4f;
    public float waveWait;
    public float scrollSpeed;
    public float tileSizeZ;
    public AudioSource backgroundMusic;
    public AudioSource winMusic;
    public AudioSource lossMusic;
   
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    public Text winText;
    public Text hardModeText;
    public Text toWinText;

    public bool winSong;
    public bool lossSong;
    public bool backgroundSong;

    private bool gameOver;
    private bool restart;
   
    public int score;

    void Start()
    {
        {
            backgroundMusic = GetComponent<AudioSource>();
           
        }

        {
            toWinText.text = "Reach 200!";
        }
        {
            hardModeText.text = "Press 'H' for Hard Mode";


            gameOver = false;
            restart = false;

            restartText.text = "";
            gameOverText.text = "";
            winText.text = "";
            score = 0;
            UpdateScore();
            StartCoroutine(SpawnWaves());
        }

    
    }
    void Update()
    {
        {
            backgroundSong = true;
            lossSong = false;
            winSong = false;
            
        }
        {
            if (score >= 200 && backgroundMusic.isPlaying)
            {
                backgroundMusic.Stop();
                backgroundSong = false;
                winSong = true;
                {
                    backgroundMusic.Stop();
                    winMusic.Play();
                }
            }

            if (gameOver && backgroundMusic.isPlaying)
            {
                
                backgroundSong = false;
                winSong = false;
                lossSong = true;
                {
                    backgroundMusic.Stop();
                    lossMusic.Play();
                }
            }
        }


        {
            if (Input.GetKey(KeyCode.H))
            {
                hardModeText.text = "Hard Mode Activated";
            }
        }
        {
            if (Input.GetKey(KeyCode.H))
            {
                hazardCount = 20f;               
                spawnWait = .3f;
                startWait = .5f;
               

            }

            if (restart)
            {
                if (Input.GetKeyDown(KeyCode.P))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
            }
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
    }
   
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver||score >=200)         {
                restartText.text = "Press 'P' to Play Again!";
                restart = true;
                break;
            }

           
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Points: " + score;
        if (score >= 200)
        {
            winText.text = "You win! Game Created by: JOSEPH SQUARTINO";
            hardModeText.text = "";
            gameOver = false;
            gameOverText.text = "";
             }
     

    }

    public void GameOver()
    {
        gameOverText.text = "Game Over! Game Created by: JOSEPH SQUARTINO";
        gameOver = true;
        hardModeText.text = "";
    }
}