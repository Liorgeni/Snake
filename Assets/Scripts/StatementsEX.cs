using UnityEngine;

public class StatementsEX : MonoBehaviour
{
    public float score;
    public float lives = 3;
    public float power = 150;
    public string ID = "";
    public Rigidbody2D rb;

    void Start()
    {
        //  CheckScore();
    }

    // Update is called once per frame
    void Update()
    {
       // UpdateLives();
       // ApplyForce();
       // ApplyGravity();
       // DisplayID();
    }


    void CheckScore()
    {
        if (score > 100)
            print("You Win");
        else if (score < 50)
            print("You Lose");
        else
            print("Try Again");
    }


    void UpdateLives()
    {

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ((lives < 10))
            {
                lives++;
                print(lives);
            }

        }

        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (lives > 0)
            {
                print(lives);
                lives--;
            }
        }


        if (lives >= 10)
            print("GOD MODE");

        if (lives <= 0)
            print("YOU DIED");
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Power" && power <= 300)
        {
            power += 50;
            if (power > 300)
            {
                power = 300;
            }
        }

        if (other.gameObject.tag == "Weak" && power >= 0)
        {
            power -= 50;
            if (power < 0)
            {
                power = 0;
            }
        }
    }


    void ApplyForce()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Vector2 force = new Vector2(50f, 0f);
            rb.AddForce(force);
            print(force);


        }
     else    if (Input.GetKeyDown(KeyCode.A))
        {
            Vector2 force = new Vector2(-50f, 00f);
            rb.AddForce(force);

            print(force);
        }
         if (Input.GetKeyDown(KeyCode.W))
        {
            Vector2 force = new Vector2(00f, 50f);
            rb.AddForce(force);

            print(force);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Vector2 force = new Vector2(00f, -50f);
            rb.AddForce(force);

            print(force);
        }
    }

    void DisplayID()
    {

        for (int i = 0; i <= 9; i++)
        {
            KeyCode key = KeyCode.Alpha0 + i;
            if (Input.GetKeyDown(key))
            {
                ID += i.ToString();
                print(ID);
            }
        }
        CheckNumber();

    }


        void ApplyGravity()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                rb.gravityScale += 1;
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                rb.gravityScale -= 1;


            print(rb.gravityScale);
        }
    
    void CheckNumber()
    {
        int idNum;


        if (int.TryParse(ID, out idNum))
        {
            if (idNum > 0)
                print("Is positive");
            else if (idNum < 0)
                print("Is negative");
            else
                print("Is 0");

        }
    }
}
