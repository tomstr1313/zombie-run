using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{
    private bool gameStarted;
    public Text continueText;
    public Text scoreText;

    private float timeElapsed = 0f;
    private float bestTime = 0f;
    private float blinkTime = 0f;
    private bool blink;



    //player reference
    public GameObject playerPrefab;
    private TimeManager timeManager;
    //player instance
    private GameObject player;
    private GameObject floor;
    private Spawner spawner;
    private bool beatBestTime;


    void Awake()
    {
        floor = GameObject.Find("Foreground");
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();
        timeManager = GetComponent<TimeManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //realign the floor

        var floorHeight = floor.transform.localScale.y;
        var pos = floor.transform.position;

        //make sure floor is always centered
        pos.x = 0;
        pos.y = -((Screen.height / PixelPerfectCamera.pixelsToUnits) / 2) + (floorHeight / 2);
        floor.transform.position = pos;

        spawner.active = false;

        Time.timeScale = 0;

        continueText.text = "Press Any Button To Start";

        bestTime = PlayerPrefs.GetFloat("BestTime");

        //RestartGame();

    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted && Time.timeScale == 0)
        {
            if (Input.anyKeyDown)
            {
                timeManager.ManipulateTime(1, 1f);
                RestartGame();
            }
        }

            //make sure game is not started
            if (!gameStarted)
            {
                blinkTime++;
                if (blinkTime % 30 == 0)
                {
                    blink = !blink;
                }
                continueText.canvasRenderer.SetAlpha(blink ? 0 : 1);

            var textColour = beatBestTime ? "#FF0" : "#FFF";

                //display time elapsed
                scoreText.text = "Time: " + FormatTime(timeElapsed) + "\n<color="+textColour+">Best: " + FormatTime(bestTime)+"</color>";
            }
        else { 

        timeElapsed += Time.deltaTime;
                scoreText.text = "Time: " + FormatTime(timeElapsed);
            
        }
    } 

    //when player dies
    public void OnPlayerKilled()
    {
        spawner.active = false;

        

        //VERY IMPORTANT
        //removes player from memory when killed, if this is not here memory will just fill up
        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback -= OnPlayerKilled;

        //reset player velocity after they die
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        timeManager.ManipulateTime(0, 5.5f);

        gameStarted = false;

        continueText.text = "Press Any Button To Restart";

        if(timeElapsed > bestTime)
        {
            bestTime = timeElapsed;
            PlayerPrefs.SetFloat("BestTime", bestTime);
            beatBestTime = true;
        }
    }

    void RestartGame()
    {
        spawner.active = true;
        //player spawn area
        player = GameObjectUtil.Instantiate(playerPrefab, new Vector3(0, (Screen.height / PixelPerfectCamera.pixelsToUnits) / 2+100, 0));

        //call when player is killed
        var playerDestroyScript = player.GetComponent<DestroyOffscreen>();
        playerDestroyScript.DestroyCallback += OnPlayerKilled;

        gameStarted = true;

        //no blink, hide text
        continueText.canvasRenderer.SetAlpha(0);
        timeElapsed = 0;

        beatBestTime = false;
    }

    //format time elapsed
    string FormatTime(float value)
    {
        TimeSpan t = TimeSpan.FromSeconds(value);
        return string.Format("{0:D2}:{1:D2}:{2:D2}", t.Minutes, t.Seconds, t.Milliseconds);
    }
}
