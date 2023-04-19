using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    public float jumpForce = 4.0f;
    public float speed = 0.0f;
    public Rigidbody2D Player;
    public gameLogic logic;
    public InputAction jump;
    private bool isAlive = true;
    private float killZone = 5.6f;
    public Animator animate;
    //Collider2D playerCollider;
    

    private void OnEnable()
    {
        jump.Enable();
    }

    private void OnDisable()
    {
        jump.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<gameLogic>();
        //playerCollider = GetComponent<Collider2D>();
        Player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (jump.triggered && isAlive)
        {
            Player.velocity = new Vector2(speed, jumpForce);
            animate.Play("earFlap");
        }
        if (Player.position.y >= killZone && isAlive) { onDeath(); }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        onDeath();
        Player.velocity = new Vector2(speed, jumpForce * 2);
    }

    private void onDeath()
    {
        logic.gameOver();
        animate.Play("catDeath");
        //playerCollider.enabled = false;
        isAlive = false;
    }
}
