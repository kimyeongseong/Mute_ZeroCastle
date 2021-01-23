using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public GameObject player;
    public GameObject cam;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Charater>().inobject = true;
        cam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void end()
    {
        player.GetComponent<SpriteRenderer>().enabled = false;
        player.GetComponent<Charater>().inobject = true;
        cam.SetActive(false);
    }
    public void start()
    {
        player.GetComponent<Charater>().inobject = false;
        player.GetComponent<SpriteRenderer>().enabled = true;
        cam.SetActive(true);
    }
}
