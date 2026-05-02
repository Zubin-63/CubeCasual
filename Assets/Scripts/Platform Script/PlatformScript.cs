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
}
