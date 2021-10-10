using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nuvem: MonoBehaviour
{
    float speed = 7;

    float visibleHeightThreshold;
    void Start(){
        visibleHeightThreshold = Camera.main.orthographicSize + transform.localScale.x;
    }
    void Update()
    {
        transform.Translate (Vector3.right * speed * Time.deltaTime);
        if (transform.position.x > visibleHeightThreshold) {
            Destroy (gameObject);
        }
    }
}