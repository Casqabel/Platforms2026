using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Sigleton<GameManager>

{
    public static int coins;
    public static int level;
    public static float health;
    public static float maxHealth;

    // Start is called before the first frame update
    void Awake()
    {
        coins = 0;
        level = 1;
        health = -100;
    }


    public void SumarMoneda(int cantidad) {

        coins += cantidad;
        Debug.Log("Tengo " + coins + "monedas");
    
    }

    public void Initialize(float maxH)
    {
        if (health == -100) {
            maxHealth = maxH;
            health = maxHealth;
        }
    }

    public void NextLevel() {
        level++;
        string levelName = "Level" + level;
        SceneManager.LoadScene(levelName);

    
    }

    public void Restart() {
        coins = 0;
        health = maxHealth;
        string levelName = "Level" + level;
        SceneManager.LoadScene(levelName);
    }

    public void ChangeHealth(float amount) {
        health += amount;
    
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
