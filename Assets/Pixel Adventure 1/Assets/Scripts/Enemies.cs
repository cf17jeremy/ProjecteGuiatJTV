using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemies : MonoBehaviour{
    public AudioSource tickSource;
    public AudioClip dmgsound;
    public AudioClip deathsound;
    public bool isanimated;
    public Text txtstate;
    public GameObject bgstate;
    Animator anim;

    void Start(){
        if(isanimated){
            anim = GetComponent<Animator>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Player"){
            if(isanimated){
                    anim.enabled = false;
            }
            if(PlayerMove.vidas <= 1){
                bgstate.gameObject.SetActive (true);
                txtstate.text = "GAME OVER";
                PlayerMove.IsInputEnabled = false;
                PlayerMove.timesdeath ++;
                tickSource.clip = deathsound;
                tickSource.Play();
                StartCoroutine("TimerDIE");
            }
            else{
                PlayerMove.IsInputEnabled = false;
                PlayerMove.vidas --;
                tickSource.clip = dmgsound;
                tickSource.Play();
                StartCoroutine("TimerDMG");
            }
            
            Destroy(collision.gameObject, tickSource.clip.length);
        }
    }

    IEnumerator TimerDMG(){
        yield return new WaitForSeconds(tickSource.clip.length);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerMove.IsInputEnabled = true;
    }

    IEnumerator TimerDIE (){
        yield return new WaitForSeconds(tickSource.clip.length);
        SceneManager.LoadScene("Menu");
        PlayerMove.IsInputEnabled = true;
    }
}