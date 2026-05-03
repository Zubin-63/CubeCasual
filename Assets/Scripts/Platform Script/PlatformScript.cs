using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{
    public float moveSpeed = 2f;
    public bool isMoveLeft, isMoveRight, isBreakable, isSpike, isPlatform;
    public float uLimit=6f;
    private Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        if(isBreakable)
        {
            anim= GetComponent<Animator>();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
    }
     void Move()
    {
        Vector2 temp=transform.position;
        temp.y+=moveSpeed*Time.deltaTime;
        transform.position=temp;
        if(transform.position.y>=uLimit) {
            Destroy(gameObject,1f);
        }
    }
    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.3f);
    }
    void DeactivateGameObject()
    {
        //sound.icebreak;
        SoundManagerScript.instance.IceBreakSound();
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Player" && isSpike)
        {
            Destroy(target.gameObject);
            SoundManagerScript.instance.DeathSound();
            GameManagerScript.instance.RestartGame();
            //soundmanager.gameover
            //gamemanager.restart
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //sound.land
            SoundManagerScript.instance.LandSound();
            if (isBreakable)
            {
                
                anim.Play("Break");
            }
           
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if(isMoveLeft)
            {
                collision.gameObject.GetComponent<MovementScript>().PlatformMove(-1f);
            }
            if(isMoveRight)
            {
                collision.gameObject.GetComponent<MovementScript>().PlatformMove(1f);
            }
        }
    }


}
