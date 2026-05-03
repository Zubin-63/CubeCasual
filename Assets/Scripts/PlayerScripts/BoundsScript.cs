using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float minX = -2.6f, maxX = 2.6f, minY = -5.6f, maxY = 5.6f;
    private bool isOutOfBounds;

    // Update is called once per frame
    void Update()
    {
        CheckBounds();
    }
    public void CheckBounds()
    {
        Vector2 temp=transform.position;
        if (temp.x > maxX)
        {
            temp.x=maxX;
        }
        if(temp.x < minX)
        {
            temp.x=minX;
        }
        transform.position = temp;
        if (temp.y <= minY)
        {
            if (!isOutOfBounds)
            {
                isOutOfBounds = true;
                SoundManagerScript.instance.DeathSound();
                GameManagerScript.instance.RestartGame();
                // sound of death
                // gamemanager restart game 
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.tag == "Spikes")
        {
            Destroy(gameObject);
            SoundManagerScript.instance.DeathSound();
            GameManagerScript.instance.RestartGame();
            SoundManagerScript.instance.DeathSound();
            GameManagerScript.instance.RestartGame();
        }
    }
}
