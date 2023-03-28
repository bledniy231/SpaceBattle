using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIEnemyCounter : MonoBehaviour {

    public Text enemyCounterText;

	void Update () {
        enemyCounterText.text = Player.enemies.Count.ToString();

    }
}
