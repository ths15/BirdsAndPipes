using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public GameObject spawner;
    public bool birdIsAlive = true;
    public bool birdIsAwake = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            if(!birdIsAwake)
            {
                spawner.SetActive(true);
                myRigidBody.WakeUp();
            }
            FindObjectOfType<AudioManager>().Play("JumpSound");
            myRigidBody.velocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        EndGame();
    }

    public void EndGame()
    {
        if(birdIsAlive)
        {
            FindObjectOfType<AudioManager>().Play("DeathSound");
            logic.GameOver();
            birdIsAlive = false;
        }
        
    }
}
