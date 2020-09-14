// Anthony Tiongson (ast119)
// https://learn.unity.com/project/roll-a-ball-tutorial
// https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html
// https://answers.unity.com/questions/1275232/disable-all-inputs.html
// https://answers.unity.com/questions/1261937/creating-a-restart-button.html
// https://www.youtube.com/watch?v=qc7J0iei3BU

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

        if ((playerOne.transform.position.y < -5) || (playerTwo.transform.position.y < -5))
        {
            transform.position = new Vector3 (0, 8, -12);
        }
    }
}
