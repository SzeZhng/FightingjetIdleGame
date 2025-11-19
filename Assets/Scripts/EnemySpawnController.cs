using UnityEngine;
using System.Collections.Generic;

public class EnemySpawnController : MonoBehaviour {
    public Transform CircleCenter;
    private GameObject EnemyType;
    public EnemySpawnManager Manager;
    public EnemyData Data; 

    private void Awake() 
    {
        Manager = GetComponent<EnemySpawnManager>();
    }
    private void Update()
    {
        // Set EnemyType to selected EnemyName
        EnemyType = GameObject.Find(Data.EnemyName);
    }

    public void PathFind(string type, float[] startpoint, float[] endpoint, float[] midpoint, float speed)
    {
        List<float[]> Waypoints = new List<float[]>(); 
        if (type == "Line")
        {
            float[] constant = Manager.LineFormula(startpoint, endpoint);

            if (constant != null)
            {
                // from left to right
                if (startpoint[0] < endpoint[0])
                {
                    for (float x = startpoint[0]; x < endpoint[0]; x = x + speed)
                    {
                        float y = constant[0] * startpoint[0] + constant[1];
                        Waypoints.Add(new float[] {x, y});
                    }
                }
                
                // from right to left
                else if (startpoint[0] > endpoint[0])
                {
                    for (float x = startpoint[0]; x > endpoint[0]; x = x - speed)
                    {
                        float y = constant[0] * startpoint[0] + constant[1];
                        Waypoints.Add(new float[] {x, y});
                    }
                }
            } else if (startpoint[1] != endpoint[1]){
                // from down to up
                float x = startpoint[0];
                if (startpoint[1] < endpoint[1])
                {
                    for (float y = startpoint[1]; y < endpoint[1]; y = y + speed)
                    {
                        Waypoints.Add(new float[] {x, y});
                    }
                }
                // from down to up
                else if (startpoint[1] > endpoint[1])
                {
                    for (float y = startpoint[1]; y > endpoint[1]; y = y - speed)
                    {
                        Waypoints.Add(new float[] {x, y});
                    }
                }
            } else {
                throw new ArgumentException("Cannot set start point and end point as the same coordinate");
            }
        }
        else if (type == "Circle")
        {
            
        }
    }
}