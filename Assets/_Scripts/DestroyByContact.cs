﻿using UnityEngine;


public class DestroyByContact : MonoBehaviour 
{
	// scoring
	private int scoreValue = 1;
	private GameController gameController;

	public GameObject explosion;

	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}

		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	// This code destroys Canon Ball and Monster!
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Boundary") 
		{
			return;
		}
        if (other.tag == "Ground")
        {
            return;
        }
        if (other.tag == "Player")
        {
            return;
        }
        if (other.tag == "Monster")
        {
            return;
        }
        Instantiate (explosion, transform.position, transform.rotation);

        if (other.tag == "Ball")
        {
            // scoring
            gameController.AddScore(scoreValue);
			Destroy(other.gameObject);
        }
			
		Destroy(gameObject);

	}

}
