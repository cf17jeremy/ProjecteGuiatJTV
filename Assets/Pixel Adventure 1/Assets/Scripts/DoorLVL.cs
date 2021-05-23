using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorLVL : MonoBehaviour{
    public string levelName;
    private bool inDoor = false;

    public Text txtdeaths;

    AudioSource tickSource;

    void Start(){
        PlayerMove.vidas = 3;
        tickSource = GetComponent<AudioSource>();
        txtdeaths.text = "Times Death: " + PlayerMove.timesdeath;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        inDoor = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        inDoor = false;
    }

    private void Update() {
        if(inDoor && Input.GetKey("e")) {
            tickSource.Play();
            PlayerMove.IsInputEnabled = false;
            StartCoroutine("Timer");
        }
    }

    IEnumerator Timer(){
        yield return new WaitForSeconds(tickSource.clip.length);
        PlayerMove.IsInputEnabled = true;
        SceneManager.LoadScene(levelName);
    }
}
