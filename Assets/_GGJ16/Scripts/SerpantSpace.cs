using UnityEngine;
using System.Collections;

public class SerpantSpace{
    public float dotAhread;
    public float dotBehind;
    public Vector2 serpantSpace;
    public int segment
    {
        get { return ((int)serpantSpace.y); }
    }
    public float percentInSegment{
        get{return serpantSpace.y-((float)segment);}
    }
    public float dotCurrent{
        get{return Mathf.Lerp(dotAhread,dotBehind,percentInSegment);}
    }
    public Vector3 worldPosition
    {
        get
        {
            //project from SS to worldSpace
            return Vector3.zero;
        }
    }
}
