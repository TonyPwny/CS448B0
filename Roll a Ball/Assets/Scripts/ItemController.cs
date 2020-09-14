// Anthony Tiongson (ast119)
// https://learn.unity.com/project/roll-a-ball-tutorial
// https://answers.unity.com/questions/1417767/c-how-to-check-if-player-is-grounded.html
// https://answers.unity.com/questions/1275232/disable-all-inputs.html
// https://answers.unity.com/questions/1261937/creating-a-restart-button.html
// https://www.youtube.com/watch?v=qc7J0iei3BU

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float respawnTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ItemPickUp(GoldCubes goldCube)
    {
        goldCube.gameObject.SetActive(false);
        StartCoroutine("Respawn", goldCube);
    }

    IEnumerator Respawn(GoldCubes goldCube)
    {
        yield return new WaitForSeconds(respawnTime);
        goldCube.gameObject.SetActive(true);
    }
}
