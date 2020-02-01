using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playercontroler : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb2d;
    private int count;
    public Text CountText;
    public Text WinText;
    private int lives;
    public Text Livetext;
    public Text Losetext;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        lives = 3;
        WinText.text = "";
        Losetext.text = "";
        SetCountText();
        SetLivesText();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

        // Update is called once per frame
        void FixedUpdate()
    {
        float moveHorizorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizorizontal,moveVertical);
        rb2d.AddForce(movement * speed);     
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("pickup"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives = lives - 1;
            SetLivesText();
        }
    }

    void SetCountText()
    {
        CountText.text = "Count: " + count.ToString();
        if (count == 7)
        {
            transform.position = new Vector2(66.7f, -9.4f);
        }
        if (count >= 15)
        { 
        WinText.text = "You win!!! Game created by Nicole Cohen!!!";
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }
    void SetLivesText()
    {
        Livetext.text = "Lives: " + lives.ToString();
        if (lives< 1)
        {
            Losetext.text = "You Lose!!! Game created by Nicole Cohen!!!";
            rb2d.bodyType = RigidbodyType2D.Static;
        }
    }
}