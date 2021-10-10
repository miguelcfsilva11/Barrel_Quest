using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PLayerController : MonoBehaviour
{
    public float speed = 7;
    public UnityEvent PlayZ;
    public event System.Action OnPlayerDeath;
    float screenHalfWidthInWorldUnits;
    public GameObject bullet;
    public static int counter = 2;

    // Start is called before the first frame update
    void Start()
    {
	counter = 2;
        StartCoroutine(Reset());
        float halfPlayerWidth = transform.localScale.x /2f;
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate (Vector2.right * velocity * Time.deltaTime);
        if (transform.position.x < -screenHalfWidthInWorldUnits) {
            transform.position = new Vector2 (screenHalfWidthInWorldUnits, transform.position.y);
        }
        if (transform.position.x > screenHalfWidthInWorldUnits) {
            transform.position = new Vector2 (-screenHalfWidthInWorldUnits, transform.position.y);
        }

        if(Input.GetKeyDown("z") && counter > 0)
        {
            PlayZ.Invoke();
            shootBullet();
            counter--;
            Reset();
        }

    }
    void OnTriggerEnter2D(Collider2D triggerCollider){
        if (triggerCollider.tag == "Falling Block") {
            if (OnPlayerDeath != null) {
                OnPlayerDeath ();
            }
            Destroy (gameObject);
            
        }
    }

    public void shootBullet()
    {
        GameObject b = Instantiate(bullet) as GameObject;
        b.transform.position = GameObject.FindWithTag("Player").transform.position;
    }
    public IEnumerator Reset(){
        while (true) {
            yield return new WaitForSeconds(7f);
            counter++;
        }
    }
}