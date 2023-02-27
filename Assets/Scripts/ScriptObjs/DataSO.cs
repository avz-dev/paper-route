using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataSO : ScriptableObject
{
    public float balance;
    public Bike bicycle;
    public bool[] bikes;

    public float Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public Bike Bicycle
    {
        get { return bicycle; }
        set { bicycle = value; }
    }

    public bool[] Bikes
    {
        get { return bikes; }
        set { bikes = value; }
    }
}
