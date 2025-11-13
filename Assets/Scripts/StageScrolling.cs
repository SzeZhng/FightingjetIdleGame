using UnityEngine;
using System;

public class StageScrolling : MonoBehaviour {
    public static float ScrollCoordinate = 0f;
    public static bool inStage = false;
    public static Vector2 TargetPosition;
    public static Vector2 ActualLocation = new Vector2(0, 0);
    public static bool StageCloned = true;
    public static string StageBGName;
    public static float AccelerationConstant;
    public static float StartingVelocity;
    public static float MaxVelocity;
    private GameObject CurrentStage;
    private GameObject DupeStage;
    private float StageMoveVelocity;
    private float Multiplier = StartingVelocity;
    private float BGHeight;

    // Testing purpose
    private void Awake()
    {
        StageCloned = false;
        StageBGName = "stagedummy_0";
        inStage = true;
        ScrollCoordinate = -200f;
        MaxVelocity = 10f;
        StartingVelocity = 0.6f;
        AccelerationConstant = 1.1f;
    }

    private void Update()
    {
        // Get stage background name and height of the background
        CurrentStage = GameObject.Find(StageBGName);
        // Check if CurrentStage exists
        if (CurrentStage != null)
        {
            Renderer renderer = CurrentStage.GetComponent<Renderer>();
            BGHeight = GetComponent<Renderer>().bounds.size.y;

            // Clone the background once and put it on top of the original background
            if (!StageCloned)
            {
                DupeStage = Instantiate(CurrentStage, new Vector3(0, BGHeight, 0), Quaternion.identity);
                StageCloned = true;
            }

            // Acceleration method
            // Increase Multiplier if smaller than MaxVelocity
            if ((ActualLocation != TargetPosition) && (Multiplier < MaxVelocity))
            {
                Multiplier = Multiplier * AccelerationConstant; 
                StageMoveVelocity = Multiplier * Time.deltaTime;
            }
            // Set Multiplier to MaxVelocity if exceed
            else if ((ActualLocation != TargetPosition) && (Multiplier > MaxVelocity))
            {
                Multiplier = MaxVelocity; 
                StageMoveVelocity = Multiplier * Time.deltaTime;
            }
            // Stop if ActualLocation is equal to TargetPosition
            else if (ActualLocation == TargetPosition)
            {
                Multiplier = StartingVelocity;
            }
            // Dynamic deacceleration when ActualLocation is almost equals to TargetPostion
            else if (((ActualLocation.y - TargetPosition.y) < MathF.Log((MaxVelocity / StartingVelocity * (1 - AccelerationConstant)) - 1, 1 - AccelerationConstant)) && (Multiplier > StartingVelocity))
            {
                Multiplier = Multiplier * (1 / AccelerationConstant); 
                StageMoveVelocity = Multiplier * Time.deltaTime;
            }

            // Only change TargetPosition in CurrentStage to prevent desync
            if (DupeStage == null)
            {
                TargetPosition = new Vector2(0, ScrollCoordinate);
            }

            // Scroll background when inStage is true and TargetPosition is smaller than ActualLocation
            // ActualLocation and TargetPosition is towards negative
            if ((inStage == true) && (ActualLocation.y > TargetPosition.y)) {
                if (DupeStage == null)
                {
                    CurrentStage.transform.position = new Vector3(0, ((ActualLocation.y - TargetPosition.y) % BGHeight) - BGHeight, 0);
                    ActualLocation = Vector2.MoveTowards(ActualLocation, TargetPosition, StageMoveVelocity);
                    Debug.Log(ActualLocation);
                }
                if (DupeStage != null)
                {   
                    DupeStage.transform.position = new Vector3(0, (ActualLocation.y - TargetPosition.y) % BGHeight, 0);
                }
            }
            else
            {
                ActualLocation = TargetPosition;
            }
        }
    }
}
