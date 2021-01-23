using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class move : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject charather;
    public int a;
    // Start is called before the first frame update
    private bool isBtnDown = false;
    public GameObject flash;
    private void Update()
    {
        if (isBtnDown&&!charather.GetComponent<Charater>().Die&& !charather.GetComponent<Charater>().inside)
        {
            if (!charather.GetComponent<AudioSource>().isPlaying)
                charather.GetComponent<AudioSource>().Play();
            if (a == 1)
            {
                charather.GetComponent<SpriteRenderer>().flipX = false;
                flash.transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            else
            {
                charather.GetComponent<SpriteRenderer>().flipX = true;
                flash.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            charather.transform.Translate(Vector3.left * Time.deltaTime * a, Space.World);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!charather.GetComponent<Charater>().inside&& !charather.GetComponent<Charater>().inobject&&!charather.GetComponent<Charater>().Die)
        {
            isBtnDown = true;
            charather.GetComponent<Animator>().SetBool("Walk", true);
            charather.GetComponent<Animator>().SetBool("Idle", false);
            charather.GetComponent<Animator>().SetFloat("x", -1);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (charather.GetComponent<AudioSource>().isPlaying)
            charather.GetComponent<Charater>().step.Stop();
        isBtnDown = false;
        charather.GetComponent<Animator>().SetBool("Idle", true);
        int a;
        a = Random.Range(1, 3);
        charather.GetComponent<Animator>().SetFloat("x", a);
        charather.GetComponent<Animator>().SetBool("Walk", false);
    }
}
