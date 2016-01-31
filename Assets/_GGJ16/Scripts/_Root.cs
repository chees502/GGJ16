using UnityEngine;
using System.Collections;

public class _Root{
    private static GameState _gameState = GameState.Splash;
    public static GameState gameState
    {
        get
        {
            return _gameState;
        }
        set
        {
            if (value == _gameState) return;
            SwitchState(_gameState, value);
            _gameState = value;
        }
    }
    private static void SwitchState(GameState old, GameState now)
    {
        switch (old)
        {
            case (GameState.Splash):
                SplashScreenController.main.Disable();
                break;
            case (GameState.Lobby):

                break;
            case (GameState.Game):

                break;
            case (GameState.PostGame):

                break;
        } 
        switch (now)
        {
            case (GameState.Splash):

                break;
            case (GameState.Lobby):

                break;
            case (GameState.Game):

                break;
            case (GameState.PostGame):

                break;
        }
    }
    private static PlayerController _flyingPlayer = null;
    public static PlayerController flyingPlayer
    {
        get { return _flyingPlayer; }
        set
        {
            if (_flyingPlayer != null)
            {
                _flyingPlayer.Respawn();
            } 
            if (value != null)
            {
                value.Mount();
                _flyingPlayer = value;
            }
        }
    }
    public static GameObject respawnNode = null;
    public static GameObject mountedNode = null;
}
