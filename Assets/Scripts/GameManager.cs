using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float GameSpeed { get; private set; }

    private Player _player;
    private Spawner _spawner;

    public static int highscore;
    public static int score;
    public float scorezaehler;


    public UnityEngine.UI.Text textscore;
    public UnityEngine.UI.Text texthighscore;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else {
            DestroyImmediate(gameObject);
        }
    }

    public void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()

    {
        _player = FindObjectOfType<Player>();
        _spawner = FindObjectOfType<Spawner>();
        
        score = 0;

        highscore = PlayerPrefs.GetInt("highscore", highscore);
        texthighscore.text = highscore.ToString();

        NewGame();
    }

    public void Update()
    {
        GameSpeed += gameSpeedIncrease * Time.deltaTime;

        scorezaehler += Time.deltaTime;

        if (scorezaehler > 0.1)
        {
            Addscore1();
            scorezaehler = 0;
        }

        if (score > highscore)
        {
            highscore = score;
           
            PlayerPrefs.SetInt("highscore", highscore);
            texthighscore.text = highscore.ToString();
        }



    }

    private void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach (var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }
        
        GameSpeed = initialGameSpeed;
        enabled = true;
        
        _player.gameObject.SetActive(true);
        _spawner.gameObject.SetActive(true);
    }

    public void GameOver()
    {
        GameSpeed = 0f;
        enabled = false; //disables manager

        _player.gameObject.SetActive(false);
        _spawner.gameObject.SetActive(false);
    }


    public void Addscore1()
    {

        score += 1;
        textscore.text = score.ToString();

    }

}
