using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cabinet : MonoBehaviour
{
    public GameObject[] charat;
    public Sprite a;
    public Sprite b;
    // Start is called before the first frame update
    void Start()
    {
        b = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (charat[0].GetComponent<Charater>().Die)
        {
            GetComponent<Animator>().enabled = false;
            GetComponent<SpriteRenderer>().sprite = b;
        }
    }
    public void start()
    {
        charat[0].GetComponent<SpriteRenderer>().enabled = false;
        charat[1].SetActive(false);
    }
    public void inside()
    {
        charat[0].GetComponent<Charater>().inside = !charat[0].GetComponent<Charater>().inside;
    }
    public void end()
    {
        charat[1].SetActive(true);
        charat[0].GetComponent<Charater>().flashstate = true;
        charat[0].GetComponent<SpriteRenderer>().enabled = true;
        charat[0].GetComponent<Charater>().inobject = false;
    }
    public void playing()
    {
        charat[0].GetComponent<Charater>().inobject = !charat[0].GetComponent<Charater>().inobject;
    }
    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        if (collision.GetComponent<Charater>().Die)
    //        {
    //            Debug.Log("hello");
    //            GetComponent<Animator>().enabled = false;
    //            GetComponent<SpriteRenderer>().sprite = b;
    //        }
    //    }
    //}
}
