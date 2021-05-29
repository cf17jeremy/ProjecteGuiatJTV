using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invencible : MonoBehaviour
{
    public AudioSource tickSource;

    // Start is called before the first frame update
    void Start(){
        tickSource = GetComponent<AudioSource>();
    }
    
    // Update is called once per frame
    void Update(){

    }

    public void OnTriggerEnter2D(Collider2D collision){
        if (collision.CompareTag("Player")){
            GetComponent<SpriteRenderer>().enabled = false;
            Enemies.isinvencible = true;
            tickSource.Play ();
            StartCoroutine("Timer");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 0.5f);
        }
    }

     IEnumerator Timer(){
        yield return new WaitForSeconds(tickSource.clip.length);
        Enemies.isinvencible = false;
    }
}
