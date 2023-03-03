using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DataSO : ScriptableObject
{
    public float balance;
    public int bicycle;
    public bool[] bikes;

    public float Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public int Bicycle
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
