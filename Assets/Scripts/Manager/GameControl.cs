using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : SingletonDontDestory<GameControl>
{
    public enum GameState{
        MainMenu,
        Playing,
        Paused,
        GameOver
    }
    public GameState gameState;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
