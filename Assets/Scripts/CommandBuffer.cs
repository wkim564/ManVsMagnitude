﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CommandBuffer : MonoBehaviour {

	public int threshold = 1;
    public int specialThreshold = 10;
	public MonsterGridMovement monster;

	public int [] moveBuffers = new int[5];
    public int specialBuffer;
    public Slider[] uiSliders = new Slider[5];

	public GameObject preFabAlert;

	public void Input(int i, string name) {
        if (i == 4) {
            specialBuffer++;
            if (specialBuffer >= specialThreshold) {
                monster.Command(i);
                specialBuffer = 0;
				alert(i,name);
            }

            uiSliders[i].value = specialBuffer;
        }
        else if (i == 5) {
            Instantiate(Resources.Load("Audio/Kappa"));
        }
        else {
            moveBuffers[i]++;

            if (moveBuffers[i] >= threshold) {
                monster.Command(i);
                moveBuffers[i] = 0;
				alert(i,name);
            }
            
            uiSliders[i].value = moveBuffers[i];
        }

    }
	void alert(int i, string name) {
		GameObject panel = GameObject.Find ("MainPanel");
		if (panel != null) {
			GameObject a = (GameObject)Instantiate (preFabAlert);
			if (i <= 3) {
				a.GetComponent<Text>().text = name + " moved the Monster!";
			}
			else {
				a.GetComponent<Text>().text = name + " activated the Special Attack!";
			}
			a.transform.SetParent (panel.transform, false);
		}
	}
}

