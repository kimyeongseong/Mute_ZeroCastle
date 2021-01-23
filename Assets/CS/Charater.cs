using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Charater : MonoBehaviour
{
    public AudioSource step;
    public AudioSource scre;
    public AudioClip screem;
    public AudioClip flashsound;
    public TextMeshProUGUI resourceText;
    public int floor;
    public bool Die;
    bool cabinet_1;
    private GameObject obj;
    public bool inside;
    public GameObject a;
    public bool inobject;
    public GameObject flash;
    public bool flashstate;
    public Sprite[] battery;
    public int battery_Gage;
    float plus, minus;
    public Image battery_Obj;
    public Camera cam;
    public GameObject black;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            GetComponent<BoxCollider2D>().enabled = !GetComponent<BoxCollider2D>().enabled;
        }
        if (flashstate && battery_Gage > 0)//켜졌을 때
        {
            plus += Time.smoothDeltaTime;
            if (plus >= 10)
            {
                plus = 0;
                battery_Gage--;
                battery_Obj.sprite = battery[battery_Gage];
                if (battery_Gage == 0)
                {
                    flash.SetActive(false);
                    flashstate = false;
                    StartCoroutine(battery_Time());
                }
            }
        }
        else if (!flashstate && battery_Gage < 3)
        {
            minus += Time.smoothDeltaTime;
            if (minus >= 7.0)
            {
                minus = 0;
                battery_Gage++;
                battery_Obj.sprite = battery[battery_Gage];
            }
        }
    }
    IEnumerator battery_Time()
    {
        flashstate = !flashstate;
        flash.SetActive(!flashstate);
        yield return new WaitForSeconds(0.5f);
        flashstate = !flashstate;
        flash.SetActive(!flashstate);
        yield return new WaitForSeconds(0.25f);
        flashstate = !flashstate;
        flash.SetActive(!flashstate);
        yield return new WaitForSeconds(0.12f);
        flashstate = !flashstate;
        flash.SetActive(!flashstate);
        yield return new WaitForSeconds(0.6f);
        flashstate = !flashstate;
        flash.SetActive(!flashstate);
        flashstate = !flashstate;
        yield return null;
    }
    public void invisible()
    {
        if (cabinet_1)
        {
            if (!inobject)
            {
                transform.position = obj.transform.position;
                flashstate = false;
                if (obj.GetComponent<Animator>().GetInteger("state") == 0)
                {
                    obj.GetComponent<Animator>().SetInteger("state", 1);
                }
                else if (obj.GetComponent<Animator>().GetInteger("state") == 1)
                {
                    obj.GetComponent<Animator>().SetInteger("state", 2);
                }
                else if (obj.GetComponent<Animator>().GetInteger("state") == 2)
                {
                    obj.GetComponent<Animator>().SetInteger("state", 1);
                }
            }
        }
    }
    public IEnumerator End()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;
    }
    public void Flash()
    {
        if (!inside && !inobject && battery_Gage > 0 && !Die)
        {
            flashstate = !flashstate;
            flash.gameObject.SetActive(flashstate);
            GetComponent<AudioSource>().PlayOneShot(flashsound);
        }
    }
    void Text1()
    {
        resourceText.text = "";
    }
    void ge()
    {
        black.SetActive(true);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            floor--;
            resourceText.text = floor.ToString() + "...";
            Invoke("Text1", 2.0f);
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        float distance = Vector3.Distance(collision.gameObject.transform.position, transform.position);
        if (distance <= 0.25f)
        {
            if (collision.gameObject.tag == "cabinet_1")
            {
                obj = collision.gameObject;
                cabinet_1 = true;
                a.SetActive(true);
                a.GetComponent<Image>().sprite = obj.GetComponent<Cabinet>().a;
            }
            if (collision.gameObject.tag == "BookCase")
            {
                collision.GetComponent<Animator>().enabled = true;
                //collision.GetComponent<AudioSource>().Play();
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == obj)
        {
            obj = null;
            cabinet_1 = false;
            a.SetActive(false);
        }
    }
}
