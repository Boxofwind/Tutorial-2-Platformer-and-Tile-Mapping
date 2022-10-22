using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public TextMeshProUGUI countText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI WinText;
    private Rigidbody2D rd2d;
    public float speed;
    private int count;
    private int lives;
    private int win;
    sound Sound;
    public GameObject Music;
    Animator anim;

    private bool facingRight = true;

    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        //score.text = scoreValue.ToString();
        count = 0;
        SetCountText();
        lives = 3;
        SetlivesText();
        WinText.gameObject.SetActive(false);
        anim = GetComponent<Animator>();
    }

        void Awake()
    {
        Sound = Music.GetComponent<sound>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))

        {
          anim.SetInteger("State", 2);
        }

        if (Input.GetKeyUp(KeyCode.W))

        {
          anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.D))

        {
          anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))

        {
          anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.S))

        {
          anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.S))

        {
          anim.SetInteger("State", 0);
        }
    }

    void FixedUpdate()
    {          
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
        
        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
       if (collision.collider.tag == "Coin")
        {
            count = count +1;
            SetCountText();
            Destroy(collision.collider.gameObject);
        }
        else if (collision.collider.tag == "Enemy")
        {
            lives = lives -1;
            Destroy(collision.collider.gameObject);
            SetlivesText();
        }

    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
            {
                if(Input.GetKey(KeyCode.W))
                {
                    rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                }
                
            }
    }


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count == 4)
        {
            addlives();
            transform.position = new Vector3(50.0f, 0.0f, 0.0f);
        }
        else if(count == 8)
        {
            speed = 0;
            SetWinText(); 
        }
    }

    void SetlivesText()
    {
        livesText.text = "Lives: " + lives.ToString();

        if(lives <= 0) 
        {
            if(gameObject.CompareTag("Player"))
            {
                Destroy(gameObject);
                SetWinText();
            }
        }
    }

    void SetWinText()
    {
        if(count == 8)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "You Win: Game Created By Matthew Anastasio";
            Sound.winsound();
        }
        else if( lives <= 0)
        {
            WinText.gameObject.SetActive(true);
            WinText.text = "YOU DIED: Game Created By Matthew Anastasio";
        }
    }
    void addlives ()
    {
        livesText.text = "Lives: " + lives.ToString();
        lives = 3;
        SetlivesText();
    }
}