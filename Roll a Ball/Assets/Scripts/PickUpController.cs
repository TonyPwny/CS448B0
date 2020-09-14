// Anthony Tiongson (ast119)
// https://learn.unity.com/project/roll-a-ball-tutorial
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(50, 30, 45) * Time.deltaTime);
    }
}
