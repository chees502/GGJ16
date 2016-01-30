using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed = 1;
    public PlayerNumber number;
    public float slideAmount = 0.1f;
    public Vector3 lateral = Vector3.right;
    public float dot = 0;
    void Update(){
        Move(GetDir());
        Buck(transform.position.x);
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
    public void Buck(float latPos)
    {
        latPos = Mathf.Clamp(latPos, -1, 1);
        float amount = latPos * Mathf.Abs(dot)+dot;
        transform.position += lateral * amount*Time.deltaTime;
    }
}
