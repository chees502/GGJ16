using UnityEngine;
using System.Collections;

public class HairDrawer : MonoBehaviour {
    LineRenderer lr;
    int index;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        lr.SetPosition(index, transform.position);
	}
    public void SetValues(LineRenderer lr, int index)
    {
        this.lr = lr;
        lr.SetWidth(0.1f, 0.1f);
        this.index = index;
    }
}
