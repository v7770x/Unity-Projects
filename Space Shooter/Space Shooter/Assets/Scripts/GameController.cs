﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait, waveWait, startWait;
    private bool restart;
    public Text endText;

	void Start () {
        endText.color =  new Color(255,255,255, 0);
        StartCoroutine(SpawnWaves());
        restart = false;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                if (restart)
                {
                    break;
                }
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                
            }
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void endGame()
    {
        //endText.color = new Color(endText.color.r, endText.color.g,endText.color.b, 1)
        endText.color = new Color(255, 255, 255, 1);
        restart = true;
        

    }
}
