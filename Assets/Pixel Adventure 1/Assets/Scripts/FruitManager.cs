using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FruitManager : MonoBehaviour{

    public Text txtfruits;
    public Text txtstate;
    public AudioSource tickSource;
    public AudioClip statgesound;
    public AudioClip cgamesound;
    public GameObject bgstate;

    public void Update() {
        AllFruitsCollected();
    }

    public void AllFruitsCollected(){
        if (transform.childCount == 0) {
            PlayerMove.IsInputEnabled = false;
            if (SceneManager.GetActiveScene().buildIndex == 2){
                bgstate.gameObject.SetActive (true);
                txtstate.text = "CONGRATS, GAME COMPLETED";
                PlayerMove.timesdeath = 0;
                PlayerMove.vidas = 3;
                tickSource.clip = statgesound;
                tickSource.Play();
                StartCoroutine("TimerGame");
            }
            else{
                tickSource.clip = cgamesound;
                tickSource.Play();
                StartCoroutine("TimerStatge");
            }
        }
        txtfruits.text = "Frutas: " + transform.childCount;
    }

    IEnumerator TimerStatge(){
        yield return new WaitForSeconds(tickSource.clip.length);
        PlayerMove.IsInputEnabled = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator TimerGame(){
        yield return new WaitForSeconds(tickSource.clip.length);
        PlayerMove.IsInputEnabled = true;
        SceneManager.LoadScene(sceneBuildIndex:0);
    }
}
