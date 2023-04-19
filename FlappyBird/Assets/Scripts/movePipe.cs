using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePipe : MonoBehaviour
{
    public float hMoveSpeed = 2;
    public float killZone = -13;
    public gameLogic logic;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<gameLogic>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.gameOverScreen.activeInHierarchy == false)
        {
            transform.position += (Vector3.left * hMoveSpeed) * Time.deltaTime;

            if (transform.position.x < killZone) { Destroy(gameObject); }
        }
    }
}
