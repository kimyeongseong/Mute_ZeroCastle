using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    public move obj;
    public int a;
    // Start is called before the first frame update
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
            a = obj.a;
            obj.a = 0;
        }
        if (collision.gameObject.tag == "Monster")
        {
            collision.gameObject.GetComponent<Monster2>().x = collision.gameObject.GetComponent<Monster2>().x * -1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            obj.a = a;
            a = 0;
        }
    }
}
