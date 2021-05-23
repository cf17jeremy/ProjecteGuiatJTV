using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour {
    public float runSpeed = 2;
    public float jumpSpeed = 3;
    public static int vidas = 3;
    public static int timesdeath = 0;

    public static bool damaged = false;
    public static bool IsInputEnabled = true;

    public static AudioSource tickSource;
    public AudioClip jumpsound;
    public AudioClip runsound;
    public Text txtvidas;

    Rigidbody2D rb2d;
    SpriteRenderer spr;
    Animator anim;

    // Start is called before the first frame update
    void Start(){
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        tickSource = GetComponent<AudioSource>();
        txtvidas.text = "Vidas: " + vidas;
        tickSource.clip = jumpsound;
    }

    // Update is called once per frame
    void Update(){
        Vector2 pos = transform.position;
        if (IsInputEnabled){
            if (Input.GetKey("d") || Input.GetKey("right")){
                pos.x += runSpeed * Time.deltaTime;
                spr.flipX = false;
                if(!tickSource.isPlaying && CheckGround.isGrounded){
                    tickSource.clip = runsound;
                    tickSource.Play();
                }
                anim.SetBool("Run", true);
            }

            else if (Input.GetKey("a") || Input.GetKey("left")){
                pos.x -= runSpeed * Time.deltaTime;
                spr.flipX = true;
                if(!tickSource.isPlaying && CheckGround.isGrounded){
                    tickSource.clip = runsound;
                    tickSource.Play();
                }
                anim.SetBool("Run", true);
            }
            else {
                tickSource.Stop();
                anim.SetBool("Run", false);
            }

            if ((Input.GetKey("w") || Input.GetKey("up") || Input.GetKey("space")) && CheckGround.isGrounded){
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                tickSource.Stop();
                tickSource.clip = jumpsound;
                tickSource.Play();
                anim.SetBool("Run", false);
                anim.SetBool("Jump", true);
            }else{
                anim.SetBool("Jump", false);
            }

            transform.position = pos;
        }
    }
}
