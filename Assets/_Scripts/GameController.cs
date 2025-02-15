﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float spawnAccelerator;
    public float spawnMinimum;
    public float startWait;
    public float waveWait;

	// scoring
	private int score;
	public TextMesh scoreText;

    void Start()
    {
       	StartCoroutine (Spawnwaves());
		score = 0;
		UpdateScore ();
    }

    IEnumerator Spawnwaves()
    {
        while(true)
        {
            yield return new WaitForSeconds(startWait);

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSecondsRealtime(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            spawnWait = spawnWait - spawnAccelerator;
            if (spawnWait <= spawnMinimum)
            {
                spawnWait = spawnMinimum;
            }
        }
    }

	public void AddScore (int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	void UpdateScore ()
	{
		scoreText.text = "score: " + score;
	}

}
