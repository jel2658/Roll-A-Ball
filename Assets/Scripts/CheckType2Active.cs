using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckType2Active : MonoBehaviour
{
    public Material[] material;
    Renderer rend;
    Collider cubeCollider;
    public GameObject type2Prefab;

    // Start is called before the first frame update
    void Start()
    {
        //mat1 = Resources.Load("Type2_Inactive", typeof(Material)) as Material;
        //mat2 = Resources.Load("Type2_Active", typeof(Material)) as Material;
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[0];
        cubeCollider = GetComponent<Collider>();
        cubeCollider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().type2)
        {
            if(!cubeCollider.isTrigger)
            {
                cubeCollider.isTrigger = true;
            }
            if (rend.sharedMaterial = material[0])
            {
                rend.sharedMaterial = material[1];
            }
        } else
        {
            if (cubeCollider.isTrigger)
            {
                cubeCollider.isTrigger = false;
            }
            if (rend.sharedMaterial = material[1])
            {
                rend.sharedMaterial = material[0];
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup_type1") || collision.gameObject.CompareTag("Pickup_type2"))
        {
            transform.position = new Vector3(randPosition(), 1.0f, randPosition());
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject newCube = Instantiate(type2Prefab, new Vector3(randPosition(), 1.0f, randPosition()), transform.rotation) as GameObject;
        }
    }

    void OnCollisionStay(Collision collision)
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
