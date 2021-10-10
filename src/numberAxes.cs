using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class numberAxes : MonoBehaviour
{
    public Text remainingAxes;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        remainingAxes.text = PLayerController.counter.ToString();
    }
}