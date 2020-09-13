// Anthony Tiongson (ast119)
// https://learn.unity.com/project/roll-a-ball-tutorial
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerOne;
    public GameObject playerTwo;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - ((playerOne.transform.position + playerTwo.transform.position)/2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // LateUpdate is called once per frame but is guaranteed to run after all items have been processed in Update
    void LateUpdate()
    {
        transform.position = ((playerOne.transform.position + playerTwo.transform.position) / 2) + offset;
    }
}
