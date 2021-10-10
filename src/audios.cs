using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audios : MonoBehaviour
{
    private AudioSource clicke;
    private AudioSource explosion;
    private AudioSource thraw;
    public AudioClip cl;
    public AudioClip ex;
    public AudioClip th;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource[] audioSources = gameObject.GetComponents<AudioSource>();
	clicke = audioSources[0];
	explosion = audioSources[1];
	thraw = audioSources[2];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clicke(){
        clicke.PlayOneShot(cl, 0.1f);
    }
    public void Explosion(){
        explosion.PlayOneShot(ex, 0.1f);
    }
    public void Thraw(){
        thraw.PlayOneShot(th, 0.1f);
    }
}