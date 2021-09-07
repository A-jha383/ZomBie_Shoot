using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_input : MonoBehaviour
{
    public AudioClip[] smashsound;
    public AudioSource audiosource01;
    public GameObject bloodEffect;

    void Start()
    {
        audiosource01 = GetComponent<AudioSource>();
    }

    void Update()
    {
        // constantly check for input
        if (Input.GetMouseButtonDown(0))
        {

            //we will ray cast
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);

            if (hit.collider != null)
            {
                if (hit.collider.tag == "Enemy")
                {
                    //killing enemy
                    DisplayBloodEffect(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                    audiosource01.PlayOneShot(smashsound[Random.Range(0,smashsound.Length)],0.5f);
                    gameObject.GetComponent<game_manager>().KillEnemy();
                }
            }
        }
    }
    private void DisplayBloodEffect(Vector2 pos)
    {
        bloodEffect.transform.position = pos;
        bloodEffect.GetComponent<Animator>().SetTrigger("smashed");

    }
}
