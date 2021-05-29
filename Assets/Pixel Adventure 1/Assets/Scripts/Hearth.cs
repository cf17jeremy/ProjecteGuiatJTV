using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hearth : MonoBehaviour
{
    public AudioSource tickSource;
    public Text txtvidas;

    // Start is called before the first frame update
    void Start(){
        tickSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update(){
        txtvidas.text = "Vidas: " + PlayerMove.vidas;
    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            GetComponent<SpriteRenderer>().enabled = false;
            PlayerMove.vidas++;
            tickSource.Play ();
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }
}
