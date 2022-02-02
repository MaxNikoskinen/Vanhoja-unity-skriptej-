using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    [HideInInspector] public bool deathScreenActive;
    [HideInInspector] public bool canJump = true;
    [HideInInspector] public bool gameOver;
    [HideInInspector] public bool levelCompleted;
    public float moveSpeed = 10f;
    public float jumpStrength = 10f;
    [SerializeField] private GameObject playerDeathEffect;
    public GameObject winScreen;
    [SerializeField] private Renderer backgroundSprite;
    [SerializeField] private Renderer groundSprite;
    [SerializeField] private Color deathBackgroundColor = Color.red;
    [SerializeField] private GameObject levelStuff;
    [SerializeField] private GameObject playerLayer0;
    [SerializeField] private GameObject playerLayer1;
    [SerializeField] private GameObject playerLayer2;
    [SerializeField] private ParticleSystem playerParticleSystem;
    public GameObject deathScreen;
    [HideInInspector] public int countdownNumber = 3;
    [HideInInspector] public float deathTime = 0.0f;
    private GameObject player;
    [HideInInspector] public Rigidbody2D playerRb;
    private PauseScreen pauseScreenClass;
    [SerializeField] private GameObject winScreenSoundEffect;
    [SerializeField] private GameObject winScreenMusic;
    private AttemptCounter attemptCounterClass;
    private AllAttemptsCounter allAttemptsCounterClass;
    private LevelWinStat levelWinStatClass;

    private void Start()
    {
        pauseScreenClass = GameObject.FindObjectOfType<PauseScreen>();
        attemptCounterClass = GameObject.FindObjectOfType<AttemptCounter>();
        allAttemptsCounterClass = GameObject.FindObjectOfType<AllAttemptsCounter>();
        levelWinStatClass = GameObject.FindObjectOfType<LevelWinStat>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        playerRb.velocity = Vector2.right * moveSpeed;
        playerParticleSystem.Pause();
        playerParticleSystem.Play();
    }

    private void Update()
    {
        if(gameOver)
        {
            if (countdownNumber == 0)
            {
                pauseScreenClass.Retry();
            }
        }

        if(pauseScreenClass.isActivated == false)
        {
            if (canJump && Input.GetMouseButton(0) || canJump && Input.GetKey(KeyCode.Space) || canJump && Input.GetKey(KeyCode.UpArrow))
            {
                playerRb.AddForce(Vector2.up * jumpStrength, ForceMode2D.Impulse);
                canJump = false;
            }
        }

        if(canJump)
        {
            playerParticleSystem.Play();
        }
        else if(!canJump)
        {
            playerParticleSystem.Pause();
        }
    }

    private void FixedUpdate()
    {
        if(gameOver)
        {
            deathTime = deathTime + Time.fixedDeltaTime;
            
            if(deathTime >= 1.00f)
            {
                deathTime = 0.00f;
                countdownNumber--;
            }
        }
    }

    public void Death()
    {
        GameObject newObject = Instantiate<GameObject>(playerDeathEffect);
        newObject.transform.position = new Vector2(player.transform.position.x, player.transform.position.y);
        player.SetActive(false);
        pauseScreenClass.music.pitch = 0.75f;
        gameOver = true;
        deathScreen.SetActive(true);
        deathScreenActive = true;
        backgroundSprite.material.color = deathBackgroundColor;
        groundSprite.material.color = deathBackgroundColor;
        
//        attemptCounterClass.counterNumber++;
    }

    public void Win()
    {
        winScreen.SetActive(true);
        levelStuff.SetActive(false);
        levelCompleted = true;
        playerRb.velocity = Vector2.right * moveSpeed;
        jumpStrength = 0f;
        playerLayer0.SetActive(false);
        playerLayer1.SetActive(false);
        playerLayer2.SetActive(false);
        canJump = false;
        winScreenSoundEffect.SetActive(true);
        winScreenMusic.SetActive(true);
        levelWinStatClass.updateStatus();
        PlayerPrefs.SetInt("CurrentAttempts", 0);
    }
}
