using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public int paperCapacity;
    public float bikeSpeed;
    public float slideDuration;
    public float stunDuration;
    public int bikeSpriteIndex;

    public Bike()
    {
        paperCapacity = 3;
        bikeSpeed = 3f;
        slideDuration = 1f;
        stunDuration = 1f;
        bikeSpriteIndex = 0;
    }
}

public class MountainBike : Bike
{
    public MountainBike()
    {
        paperCapacity = 30;
        slideDuration = 0.4f;
        stunDuration = 0.8f;
        bikeSpeed = 2f;
        bikeSpriteIndex = 3;
    }
}

public class RoadBike : Bike
{
    public RoadBike()
    {
        paperCapacity = 30;
        slideDuration = 1.2f;
        stunDuration = 1.4f;
        bikeSpeed = 3.5f;
        bikeSpriteIndex = 2;
    }
}

public class BasketBike : Bike
{
    public BasketBike()
    {
        paperCapacity = 35;
        slideDuration = 1f;
        stunDuration = 1f;
        bikeSpeed = 3f;
        bikeSpriteIndex = 1;
    }
}
