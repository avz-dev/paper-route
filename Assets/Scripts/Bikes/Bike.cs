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
    public string bikeAnimation;

    public Bike()
    {
        paperCapacity = 30;
        bikeSpeed = 2.5f;
        slideDuration = 1f;
        stunDuration = 1.5f;
        bikeSpriteIndex = 0;
        bikeAnimation = "PlayerIdleAnimation";
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
        bikeAnimation = "MountainBikeAnim";
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
        bikeAnimation = "RoadBikeAnim";
    }
}

public class BasketBike : Bike
{
    public BasketBike()
    {
        paperCapacity = 35;
        slideDuration = 1f;
        stunDuration = 1.5f;
        bikeSpeed = 2.5f;
        bikeSpriteIndex = 1;
        bikeAnimation = "BasketBikeAnim";
    }
}
