using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Idle, Walk, Chase, Attack
};
public class Monster2 : MonoBehaviour
{
    public State State { get; set; }
    public Animator ZomBie_Animator { get; set; }
    public int x;
    int ZombieState;
    public AudioSource[] State_Sound;
    int Sound_Previous;
    public GameObject target;
    public bool corutin;
    bool attack;
    public float speed;
    public float speed2;
    private void Start()
    {
        ZomBie_Animator = GetComponent<Animator>();
        StartCoroutine(GetZombie_Move_State());
    }
    private void FixedUpdate() => StateSet();

    public IEnumerator GetZombie_Move_State()
    {
        corutin = true;
        x = Random.Range(-1, 2);
        switch (x)
        {
            case -1:
                State = State.Walk;
                break;
            case 0:
                State = State.Idle;
                break;
            case 1:
                State = State.Walk;
                break;
            default:
                break;
        }
        yield return new WaitForSeconds(7.7f);
        corutin = false;
        StartCoroutine(GetZombie_Move_State());
        yield return null;
    }
    private void AnimationReset()
    {
        ZomBie_Animator.SetBool("Idle", false);
        ZomBie_Animator.SetBool("Walk", false);
        ZomBie_Animator.SetBool("Run", false);
        switch (x)
        {
            case -1:
                GetComponent<SpriteRenderer>().flipX = true;
                break;
            case 1:
                GetComponent<SpriteRenderer>().flipX = false;
                break;
        }
    }
    public void Soundset(int a)
    {
        for (int b = 0; b < State_Sound.Length; b++)
            State_Sound[b].Stop();
        State_Sound[a].Play();
    }
    //public void SoundSet()
    //{
    //    if (Sound_Previous != (int)State)
    //        State_Sound[Sound_Previous].Stop();
    //    Sound_Previous = (int)State;
    //    State_Sound[(int)State].Play();
    //}
    private void StateSet()
    {
        AnimationReset();
        switch (State)
        {
            case State.Idle:
                ZomBie_Animator.SetBool("Idle", true);
                x = 0;
                break;
            case State.Walk:
                if (!attack)
                transform.Translate((Vector3.left * x *speed* Time.smoothDeltaTime) / 2);
                ZomBie_Animator.SetBool("Walk", true);
                break;
            case State.Chase:
                if (!target)
                {
                    corutin = false;
                    StopAllCoroutines();
                }
                if (target.transform.position.x < transform.position.x - 0.5f&&target!=null)
                {
                    x = 1;
                    corutin = false;
                    StopAllCoroutines();
                    ZomBie_Animator.SetBool("Run", true);
                }
                else if (target.transform.position.x > transform.position.x + 0.5f && target != null)
                {
                    x = -1;
                    corutin = false;
                    StopAllCoroutines();
                    ZomBie_Animator.SetBool("Run", true);
                }
                if (!attack)
                    transform.Translate((Vector3.left * x * speed2 * Time.smoothDeltaTime) / 2);
                break;
            case State.Attack:
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!collision.GetComponent<Charater>().Die)
            {
                Charater player = collision.gameObject.GetComponent<Charater>();
                if (player.inside)
                {
                    Debug.Log("hello");
                    target = null;
                }
                if (!player.inside)
                {
                    attack = true;
                    transform.position = new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
                    StopAllCoroutines();
                    corutin = false;
                    StartCoroutine(player.End());
                    player.cam.gameObject.GetComponent<Animation>().enabled = true;
                    player.Invoke("ge", 1.0f);
                    player.flash.SetActive(false);
                    player.flashstate = false;
                    player.Die = true;
                    player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                    AnimationReset();
                    ZomBie_Animator.SetBool("Kill", true);
                }
               
            }
        }
        if (collision.gameObject == target)
        {
            target = null;
            StartCoroutine(GetZombie_Move_State());
        }
    }
}