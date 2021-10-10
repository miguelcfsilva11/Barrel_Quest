using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameover : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject rem;
    public Text secondsSurvivedUI;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<PLayerController> ().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            if (Input.GetKeyDown (KeyCode.Space)) {
                SceneManager.LoadScene (1);

            }
            if(Input.GetKeyDown("x"))
            {
                Application.Quit();
            }
        }
        
    }
    void OnGameOver (){
        rem.SetActive (false);
        gameOverScreen.SetActive (true);
        secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        gameOver = true;
    }
}
