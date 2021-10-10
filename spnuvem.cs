using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spnuvem : MonoBehaviour
{
    public GameObject nuvemPrefab;
    public Vector2 secondsBetweenSpawnsMinMax;
    float nextSpawnTime;
    Vector2 screenHalfSizeWorldUnits;
    // Start is called before the first frame update
    void Start()
    {
        screenHalfSizeWorldUnits = new Vector2 (Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime) {
            float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y, secondsBetweenSpawnsMinMax.x, Difficulty.GetDifficultyPercent());
            nextSpawnTime = Time.time + secondsBetweenSpawns;

            Vector2 spawnPosition = new Vector2 (-screenHalfSizeWorldUnits.x - 5f, Random.Range (-screenHalfSizeWorldUnits.y, screenHalfSizeWorldUnits.y));
            Instantiate (nuvemPrefab, spawnPosition, Quaternion.identity);
        }
    }
}