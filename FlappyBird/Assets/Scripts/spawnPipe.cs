using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPipe : MonoBehaviour
{
    public GameObject Pipe;
    public float spawnRate = 3.0f;
    private float timer = 0.0f;
    public gameLogic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<gameLogic>();
        newPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.gameOverScreen.activeInHierarchy == false)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                newPipe();
                timer = 0;
            }
        }
    }

    void newPipe()
    {
        // 1.25 - 4.65 for y-value of pipes
        Instantiate(Pipe, new Vector3(transform.position.x, Random.Range(1.25f, 4.65f), transform.position.z), transform.rotation);
    }
}
