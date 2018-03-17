using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text ScoreUpdateText;
    public int score;
	void Start () {
        score = 0;
        ScoreUpdateText.text = score.ToString();
	}
}
