﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public PlayerNumber number;
    public IList<PlayerController> players = new List<PlayerController>();
    public PlayerState playerState = PlayerState.Inactive;
    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            //Do Pretty Shit
            _score = value;
            Debug.Log(gameObject.name + " now has " + _score);
        }
    }
    public float slideAmount = 0.1f;
    public Vector3 lateral = Vector3.right;
    public float dot = 0;
    public bool isFlying
    {
        get { return _Root.flyingPlayer==this; }
        set { _Root.flyingPlayer = this; }
    }
    void Awake()
    {
        players.Add(this);
    }
    void Update(){
        Move(GetDir());
        Buck(transform.position.x);
    }
    public void Move(Vector3 dir){
        if (isFlying)
        {
            Serpent.HeadControl.main.Move(dir);
        }
        else
        {
            transform.position += dir * speed * Time.deltaTime;
        }
    }
    public Vector3 GetDir(){
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis(number.ToString() + "x");
        dir.z = -Input.GetAxis(number.ToString() + "y");
        return dir;
    }
    public void Buck(float latPos)
    {
        latPos = Mathf.Clamp(latPos, -1, 1);
        float amount = latPos * Mathf.Abs(dot)+dot;
        transform.position += lateral * amount*Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Reins")
        {
            isFlying = true;
            Debug.Log("Hit the Reins.");
        }
    }
    public void Mount()
    {
        transform.position = _Root.mountedNode.transform.position;
    }
    public void Respawn()
    {
        transform.position = _Root.respawnNode.transform.position;
    }
}
