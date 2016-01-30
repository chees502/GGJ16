using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public PlayerNumber number;
    void Update(){
        Move(GetDir());
    }
    public void Move(Vector3 dir){
        transform.position += dir*speed*Time.deltaTime;
    }
    public Vector3 GetDir(){
        Vector3 dir = Vector3.zero;
        dir.x = Input.GetAxis(number.ToString() + "x");
        dir.z = -Input.GetAxis(number.ToString() + "y");
        return dir;
    }
}
