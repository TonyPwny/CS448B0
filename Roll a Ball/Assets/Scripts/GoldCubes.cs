// Anthony Tiongson (ast119)
// https://learn.unity.com/project/roll-a-ball-tutorial
// https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html
// https://answers.unity.com/questions/1275232/disable-all-inputs.html
// https://answers.unity.com/questions/1261937/creating-a-restart-button.html
// https://www.youtube.com/watch?v=qc7J0iei3BU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCubes : MonoBehaviour
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

    void OnTriggerEnter(Collider collision)
    {
        if (GameController.inPlay && collision.gameObject.CompareTag("Player"))
        {
            transform.parent.GetComponent<ItemController>().ItemPickUp(this);
        }
    }
}
