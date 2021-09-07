using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class game_manager : MonoBehaviour
{
    public GameObject [] zombies;
    public bool isRising =false;
    public bool isFalling = false;
    private int activezombieindex = 0;
    private Vector2 startPosition;
    private int zombiesSmashed;
    public int raiseSpeed = 2;
    private int liferemaining;
    private bool gameover;
    public Image life01;
    public Image life02;
    public Image life03;
    public Text scoreboard;
    public Button gameoverbutton;
    public int scorethreshold = 5;


    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        zombiesSmashed = 0;
        liferemaining = 3;
        pickNewZombie();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameover)
        {
            if (isRising)
            {
                //up logic

                if (zombies[activezombieindex].transform.position.y - startPosition.y >= 2.5f)
                {
                    //start bringing down
                    isRising = false;
                    isFalling = true;
                }
                else
                {
                    zombies[activezombieindex].transform.Translate(Vector2.up * Time.deltaTime * raiseSpeed);
                }
            }
            else if (isFalling)
            {
                //down logic
                if (zombies[activezombieindex].transform.position.y - startPosition.y <= 0f)
                {
                    //stop making it fall
                    liferemaining--;
                    isFalling = false;
                    isRising = false;
                    updateLife();
                    if (liferemaining == 0)
                    {
                        gameover = true;
                    }
                }
                else
                {
                    zombies[activezombieindex].transform.Translate(Vector2.down * Time.deltaTime * raiseSpeed);

                }

            }
            else
            {
                //anything else
                zombies[activezombieindex].transform.position = startPosition;
                pickNewZombie();
            }
        }
    }

    private void updateLife()
    {
        if (liferemaining == 3)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(true);
        }
        if (liferemaining == 2)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(true);
            life03.gameObject.SetActive(false);
        }
        if (liferemaining == 1)
        {
            life01.gameObject.SetActive(true);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);
        }
        if (liferemaining == 0)
        {
            // game over
            life01.gameObject.SetActive(false);
            life02.gameObject.SetActive(false);
            life03.gameObject.SetActive(false);
            gameover = true;
            gameoverbutton.gameObject.SetActive(true);
        }
    }

    private void pickNewZombie()
    {
        isRising = true;
        isFalling = false;
        activezombieindex = UnityEngine.Random.Range(0, zombies.Length); // this is going to get index
        GameObject activeZombie = zombies[activezombieindex];
        
        startPosition = zombies[activezombieindex].transform.position;

    }
    public void KillEnemy()
    {
        zombiesSmashed++;
        Increasespeed();
        scoreboard.text = zombiesSmashed.ToString();
        zombies[activezombieindex].transform.position = startPosition;
        pickNewZombie();
    }

    private void Increasespeed()
    {
        if (scorethreshold==zombiesSmashed)
        {
            raiseSpeed++;
            scorethreshold *= 2;
        }
    }
    public void Onrestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Onmainmenu()
    {
        SceneManager.LoadScene(0);
    }
}
