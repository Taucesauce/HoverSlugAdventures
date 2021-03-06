﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Assets.Scripts.ObjectScripts
{
    public class HUD : MonoBehaviour
    {
        public Player player;
        public Camera camera;
        private float hudSpeed = 3;
        private Button restartButton;
        private Text movesRemaining;
        public Text levelComplete;
        private AudioSource lowMoves;

        //Lerp Variables
        private float startTime;
        private float distance;
        private float distCovered;
        private float fracJourney;
        private bool lerpingToCamera;

        private Vector3 tempPlayerPos;
        private Vector3 tempHUDPos;
        private Vector3 hudYOffset = new Vector3(0f, 16.5f, 0f);
        private Vector3 cameraLerpOffset = new Vector3(0f, -3f, 10f);

        void Awake()
        {
            lowMoves = gameObject.GetComponent<AudioSource>();
            restartButton = gameObject.GetComponentInChildren<Button>();
            movesRemaining = gameObject.GetComponentInChildren<Text>();
        }
        // Update is called once per frame
        void Update()
        {
            if(player == null)
            {
                movesRemaining.text = "42";
            }

            movesRemaining.text = player.Moves.ToString();
            movesRemaining.color = setColor();
            if(player.LevelCompleted == true)
            {
                LevelComplete();
            }
            else
            {
                levelComplete.gameObject.SetActive(false);
            }

            if (lerpingToCamera && tempHUDPos != this.transform.position)
            {
                startTime = Time.time;
                distance = Vector3.Distance(this.transform.position, camera.transform.position);
            }
            else if (tempPlayerPos != player.transform.position)
            {
                startTime = Time.time;
                distance = Vector3.Distance(this.transform.position, player.transform.position);
            }

            if (player.Moves == 0 || Input.GetKey(KeyCode.E))
            {
                lerpingToCamera = true;
                lerpToCamera();


            }

            else if (player.Moves > 0)
            {
                lerpingToCamera = false;
                lerpToPlayer();

            }

            tempHUDPos = this.transform.position;
            tempPlayerPos = player.transform.position;
        }

        private void lerpToCamera()
        {
			//I will get this working eventually.
			//if (player.Moves >= 0)
			//{AkSoundEngine.PostEvent ("Play_HudZoomIn", gameObject);}
            distCovered = (Time.time - startTime) * hudSpeed;
            fracJourney = distCovered / distance;
            this.transform.position = Vector3.Lerp(this.transform.position, camera.transform.position + cameraLerpOffset, fracJourney);

        }
        private void lerpToPlayer()
        {
			//I will get this working eventually also
			//if (player.Moves >= 0)
			//{AkSoundEngine.PostEvent ("Play_HudZoomOut", gameObject);}
            distCovered = (Time.time - startTime) * hudSpeed;
            fracJourney = distCovered / distance;
            this.transform.position = Vector3.Lerp(this.transform.position, player.transform.position + hudYOffset, fracJourney);

        }

        private int tempMoves;
        Color setColor()
        {
            if (player.Moves < 4)
            {
                if (player.Moves != tempMoves)
                {
                    //lowMoves.Play();
					AkSoundEngine.PostEvent ("Play_MoveCount", gameObject);
                }
                tempMoves = player.Moves;
                return Color.red;
            }
            else
            {
                tempMoves = player.Moves;
                return Color.cyan;
            }
        }

        public void LevelComplete()
        {
            lerpingToCamera = true;
            movesRemaining.gameObject.SetActive(false);
            player.setMoves(0);
            restartButton.gameObject.SetActive(false);
            levelComplete.gameObject.SetActive(true);
        }
    }
}
