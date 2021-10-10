using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class bullet : MonoBehaviour
{
    public float speed = 5.0f;
    private GameObject bom;
    private GameObject manager;
    public GameObject explosion;
    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y > screenBounds.y){
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Falling Block")
        {
            Destroy(other.gameObject);
            PlayE();
            explosion.transform.position = transform.position;
            bom = Instantiate(explosion);
            Destroy(this.gameObject);
	    Destroy(bom,0.4f);
        }
    }
    void PlayE(){
        manager = GameObject.FindWithTag("audio");
        manager.GetComponent<audios>().Explosion();
        
    }
}
