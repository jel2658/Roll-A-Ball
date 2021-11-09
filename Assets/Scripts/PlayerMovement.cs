using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;

    public float timer;

    public int timerActivations;

    public bool type2;

    private Rigidbody rb;

    public GameObject type2Prefab;

    //private GameObject[] pickups2Array; // Help from https://answers.unity.com/questions/1693789/how-to-effect-a-few-gameobjects-with-the-same-tag.html

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        type2 = false;
        timer = 0;
        timerActivations = 0;
    }

    void Update()
    {
        if (timer > 0 && type2 == true)
        {
            timer -= Time.deltaTime;
            Debug.Log(timer);
        } else if (timer <= 0 || type2 == false)
        {
            type2 = false;
            timer = 0;
        }
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
        if (other.gameObject.CompareTag("Pickup_type1"))
        {
            type2 = true;
            timer = 10 - timerActivations;
            if (timer <= 1)
            {
                timer = 1.0f;
            }
            /*pickups2Array = GameObject.FindGameObjectsWithTag("Pickup_type2"); // Finds all pickups of type 2
            foreach (GameObject p2 in pickups2Array)
            {

            }*/
            timerActivations++;
            other.gameObject.SetActive(false);
        }

        if (other.gameObject.CompareTag("Pickup_type2"))
        {
            if (type2 == true)
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    void OnColliderEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup_type2"))
        {
            GameObject newCube = Instantiate(type2Prefab) as GameObject;
            newCube.transform.position = new Vector3(randPosition(), 1.0f, randPosition());
        }
    }

    void OnColliderStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup_type2"))
        {
            GameObject newCube = Instantiate(type2Prefab) as GameObject;
            newCube.transform.position = new Vector3(randPosition(), 1.0f, randPosition());
        }
    }

    public float randPosition()
    {
        double random = new System.Random().NextDouble() * (9 - -9) + -9;
        float f = (float)random;
        return f;
    }
}
