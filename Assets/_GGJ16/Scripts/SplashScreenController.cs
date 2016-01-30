using UnityEngine;
using System.Collections;

public class SplashScreenController : MonoBehaviour {
    public static SplashScreenController main;
    void Awake()
    {
        main = this;
    }
    public void Disable()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
        if (Time.time > 5)
        {
            _Root.gameState = GameState.Lobby;
        }
    }
}
