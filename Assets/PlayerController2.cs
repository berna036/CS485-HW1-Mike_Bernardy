using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController2 : MonoBehaviour
{

    private float speed = 10;
    public Text countText;
    public Text returnCount;
    public Text winText;


    private Rigidbody rb;
    private int count;
    private float timeLeft = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
        returnCount.text = "";
    }
    void Update()
    {

        if (count >= 12)
        {
            timeLeft = timeLeft - Time.deltaTime;
            returnCount.text = "Returing to Main Menu " + Mathf.Round(timeLeft);
            if (timeLeft < 1)
            {

                SceneManager.LoadScene("Title Menu");
            }

        }
        //speed = 10;

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);



        rb.AddForce(movement * speed);


    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
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
    public void resetSpeed()
    {
        speed = 0;
    }


}


