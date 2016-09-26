using UnityEngine;
using System.Collections;

public class Treansport2 : MonoBehaviour {

    public GameObject Player;
    public GameObject Start = null;
    private bool Teleport = false;



    void Update()
    {
        if (Teleport == true)
        {
            Player.transform.position = (Start.transform.position + new Vector3(0f, .6f, 0f));
            //Player.speed = 0;


        }
        Teleport = false;
    }
    void OnTriggerEnter(Collider other)
    {
        //if (other.gameObject.CompareTag ("Player"))
        // {
        //other.transform.position = new Vector3(0.04f, 4f, -3.87f);
        //other.transform.position = StartPoint.transform.position;


        //}
        Teleport = true;
    }
}
