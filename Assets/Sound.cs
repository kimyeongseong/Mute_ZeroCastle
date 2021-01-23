using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public Monster2 taget;
    private void Start()
    {
        taget = gameObject.transform.parent.GetComponent<Monster2>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.GetComponent<Charater>().inside)
            {
                taget.State = State.Chase;
                taget.target = collision.gameObject;
            }
            else
            {
                if (!taget.corutin)
                    StartCoroutine(taget.GetZombie_Move_State());
                taget.target = collision.gameObject;
            }
        }
        if (collision.gameObject.tag == "sound")
        {
            taget.State = State.Chase;
            taget.target = collision.transform.parent.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!taget.corutin)
                StartCoroutine(taget.GetZombie_Move_State());
            taget.target = null;
        }
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "sound")
        {
        
        }
    }
}
