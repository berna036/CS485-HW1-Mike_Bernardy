using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;
    public  float jump;
    public Text countText;
    public Text returnCount;
    public Text winText;
    public GameObject OutOfBounds;
    public GameObject FinishPad;
        
    private Rigidbody rb;
    private int count;
    private float timeLeft = 10;
    private bool resetPlayer = false;
    private bool onGround= false;
    private bool Finish = false;
    
   // private int jumpCount=0;
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        returnCount.text = "";
    }
    void Update()
    {
        if(Finish == false)
        {
            winText.text = "";
            returnCount.text = "";
        }
       
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }
        if (count >= 12  || Finish == true)
        {
            winText.text = "You Win!";
            timeLeft = timeLeft - Time.deltaTime;
            returnCount.text = "Returing to Main Menu " + Mathf.Round(timeLeft);
            if (timeLeft < 1)
            {

                SceneManager.LoadScene("Title Menu");
            }
        

        }
        if (resetPlayer == true)
        {
            //rb.velocity = Vector3.zero;
            rb.isKinematic = true;
        }
        resetPlayer = false;
        rb.isKinematic = false;
       


    }
    void FixedUpdate()
    {
      
        // jumpCount = 0;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
     
        if (Input.GetKeyDown(KeyCode.Space) && onGround==false)
        {
            //rb.AddForce(movement.up * jump);
           movement.y = jump;
            rb.AddForce(movement);
          // jumpCount++;

       }
        rb.AddForce(movement * speed);
       // onGround = false;
        //rb.AddForce(movement * speed);



        //rb.AddForce (movement * speed);


    }

    
    
    void OnTriggerEnter(Collider other)
    {
        if ( other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
        if (other.gameObject == OutOfBounds)
        {
            resetPlayer = true;
        }
        if (other.gameObject == FinishPad)
        {
            Finish = true;
        }


    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
            
        }
    }

    // void OnCollisonEnter()
    //{

    //   onGround = true;
    //}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Untagged" && onGround == true)
        {
            onGround = false;
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Untagged" && onGround == true)
        {
            onGround = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        onGround = true;
    }
    




}


