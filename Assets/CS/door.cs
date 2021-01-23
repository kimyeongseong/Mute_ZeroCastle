using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door : MonoBehaviour
{
    public Transform Door;
    public GameObject player;
    public GameObject image;
    public int num;
    public GameObject startPos;
    private void Awake()
    {
        player.GetComponent<Charater>().floor = (PlayerPrefs.GetInt("floor_num"));
        if (PlayerPrefs.GetInt("floor_num") == 0)
        {
            Debug.Log("helo");
            PlayerPrefs.SetInt("floor_num", 5);
        }
        if (num == PlayerPrefs.GetInt("floor_num"))
        {
            transform.parent.gameObject.SetActive(true);
            player.transform.position = startPos.transform.position;
        }
        else
        {
            transform.parent.gameObject.SetActive(false);
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player = collision.gameObject;
            player.GetComponent<Charater>().inside = true;
            GetComponent<Animator>().enabled = true;
            player.GetComponent<SpriteRenderer>().enabled = false;
            PlayerPrefs.SetInt("floor_num", num - 1);
if(   PlayerPrefs.GetInt("floor_num")==0)
{       
 SceneManager.LoadScene(4);
}
        }
    }
    public void next()
    {
        player.transform.position = new Vector2(Door.transform.position.x, Door.transform.position.y);
        player.GetComponent<Charater>().inside = false;
        gameObject.transform.parent.gameObject.SetActive(false);//-2.5
        player.GetComponent<SpriteRenderer>().enabled = true;
        Door.transform.parent.gameObject.SetActive(true);
    }
    public void nextstage()
    {
        image.SetActive(true);
        Invoke("next", 0.8f);
    }
}
