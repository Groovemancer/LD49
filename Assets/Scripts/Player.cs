using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigidbody;

    public float movementScalar = 10;
    public Vector2 jetPackStrength = new Vector2();
    public float jetPackMaxStrength = 3f;

    public float acceleration = 10f;
    public float deceleration = 10f;

    float scaleX;

    public Vector2 jetpackDir = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        jetpackDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Flip();

        Movement();
    }

    void Flip()
    {
        if (jetpackDir.x > 0)
        {
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        if (jetpackDir.x < 0)
        {
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        }
    }


    void Movement()
    {
        jetpackDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (jetpackDir.x > 0)
        {
            if (jetPackStrength.x < jetPackMaxStrength)
            {
                jetPackStrength.x += acceleration * Time.deltaTime;
            }
        }
        else if (jetpackDir.x < 0)
        {
            if (jetPackStrength.x > -jetPackMaxStrength)
            {
                jetPackStrength.x -= acceleration * Time.deltaTime;
            }
        }
        else
        {
            if (jetPackStrength.x > 0)
            {
                jetPackStrength.x -= acceleration * Time.deltaTime;
                if (jetPackStrength.x <= 0)
                {
                    jetPackStrength.x = 0;
                }
            }
            else if (jetPackStrength.x < 0)
            {
                jetPackStrength.x += acceleration * Time.deltaTime;
                if (jetPackStrength.x >= 0)
                {
                    jetPackStrength.x = 0;
                }
            }
        }

        if (jetpackDir.y > 0)
        {
            if (jetPackStrength.y < jetPackMaxStrength)
            {
                jetPackStrength.y += acceleration * Time.deltaTime;
            }
        }
        else if (jetpackDir.y < 0)
        {
            if (jetPackStrength.y > -jetPackMaxStrength)
            {
                jetPackStrength.y -= acceleration * Time.deltaTime;
            }
        }
        else
        {
            if (jetPackStrength.y > 0)
            {
                jetPackStrength.y -= acceleration * Time.deltaTime;
                if (jetPackStrength.y <= 0)
                {
                    jetPackStrength.y = 0;
                }
            }
            else if (jetPackStrength.y < 0)
            {
                jetPackStrength.y += acceleration * Time.deltaTime;
                if (jetPackStrength.y >= 0)
                {
                    jetPackStrength.y = 0;
                }
            }
        }

        rigidbody.velocity = new Vector2(jetPackStrength.x, jetPackStrength.y) + GameManager.Instance.gravity;
    }
}
