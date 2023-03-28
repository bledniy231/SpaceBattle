using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour {

    public static Spaceship spaceship;

    public static List<UFO> enemies;

    public static bool hasFinished;

    public bool checkVictory = false;

    public GameObject defeatUI;
    public GameObject vicrotyUI;

    private void Awake()
    {
        hasFinished = false;
        enemies = new List<UFO>();
    }

    void Update ()
    {
        if (checkVictory)
        {
            if (hasFinished == false)
            {
                if (spaceship == null)
                {
                    Defeat();
                }

                if (enemies.Count == 0)
                {
                    Victory();
                }
            }
        }
	}

    void Defeat()
    {
        hasFinished = true;
        defeatUI.SetActive(true);
    }

    void Victory()
    {
        hasFinished = true;
        vicrotyUI.SetActive(true);
    }

    public void Restart()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
}
