using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    private Vector2 direction = Vector2.right;
    private Vector2 lastDirection;
    public ParticleSystem deathEffect;

    void Start()
    {
        transform.position = new Vector2(0, 0);
        if (deathEffect != null)
        {
            deathEffect.Stop();
        }
    }

    void Update()
    {
        HandleInput();
        Move();
    }

    private void HandleInput()
    {
        // Capture the current direction to prevent reversing
        lastDirection = direction;

        // Update direction based on user input
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            if (lastDirection != Vector2.down)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
                direction = Vector2.up;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            if (lastDirection != Vector2.up)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
                direction = Vector2.down;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (lastDirection != Vector2.right)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                direction = Vector2.left;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (lastDirection != Vector2.left)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                direction = Vector2.right;
            }
        }
    }

    private void Move()
    {
        // Move the snake in the current direction at the set speed
        transform.position = new Vector2(
            transform.position.x + direction.x * speed * Time.deltaTime,
            transform.position.y + direction.y * speed * Time.deltaTime
        );
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Fruit")
        {
            Destroy(other.gameObject);
            speed += 2f;
            transform.localScale = new Vector3(transform.localScale.x + 1, transform.localScale.y, transform.localScale.z);
        }

        if (other.gameObject.tag == "Wall")
        {
        Instantiate(deathEffect, transform.position, transform.rotation);
        Destroy(gameObject);
        }


    }

}


// dirX =  Input.GetAxis("Horizontal");
// xPos = xPos + dirX * speed;        


//if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && transform.position.x <= 9.5f - (transform.localScale.x - 1) / 2)
//{
//    xPos = 1;
//    transform.rotation = Quaternion.Euler(0f, 0f, 0f);

//    //transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y , transform.localScale.z);


//}
//else if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && transform.position.x >= -9.5f - (transform.localScale.x - 1) / 2)
//{
//    xPos = -1;
//    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
//    //  transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);


//}
//else
//{
//    xPos = 0;
//}


//if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) && transform.position.y <= 4.497f - (transform.localScale.x - 1) / 2)
//{
//    yPos = 1;
//    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 90f);
//}
//else if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) && transform.position.y >= -4.497f - (transform.localScale.x - 1) / 2)
//{
//    yPos = -1;
//    transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, -90f);

//}
//else
//{
//    yPos = 0;
//}
