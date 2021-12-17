using System;
using System.Collections;
using System.Collections.Generic;
using Script.Player;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats Instance { get; set; }

    [SerializeField]    private float sanityLevel = 0;
    private float maxSanityLevel = 0;
    [SerializeField]    private float hungerLevel = 0;
    private float maxHungerLevel = 0;
    [SerializeField]    private float humidityLevel = 0;
    private float maxHumidityLevel = 0;
    [SerializeField]    private float healtLevel = 0;
    private float maxHealtlevel = 0; 
    [SerializeField]    private double temperatureLevel = 0;
    private float maxTemperatureLevel = 0;

    private float timeToCheckIfIGetHitted = 0f;
    private float debounceTimeToGetAnotherHit = 1f;

    /// <summary>
    /// Multipler the lose of the hunger meter over the time, can be 0 to 1
    /// </summary>
    [SerializeField]
    private float hungerConsume = 0f;

    /// <summary>
    /// Mutiplier the lose of the sanity, can be 0 to 1
    /// </summary>
    [SerializeField]
    private float sanityConsume = 0f;


    /// <summary>
    /// Indicates if the player it's playing
    /// </summary>
    public bool thePlayerItsAlive = false;

    //Actions (OUTSIDE CAN AFFECT THEIR INSIDE CODE, MONSTER, FOOD, NIGHT)
    public delegate void PlayerStatsDelegate(PlayerStats playerStats);
    public event PlayerStatsDelegate playerStatsDelegate;

    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        SetAllStatus(100,100,0, 100, 0,0);
        CopyStatus();
        StartBasicRoutine();
    }
    
    private void SetAllStatus(int sanity, int hunger, int humidity,int health, int hungerConsume, int sanityConsume)
    {
        sanityLevel = sanity;
        hungerLevel = hunger;
        humidityLevel = humidity;
        healtLevel = health;

        this.hungerConsume = hungerConsume;
        this.sanityConsume = sanityConsume; 

        thePlayerItsAlive = true;
    }

    private void CopyStatus()
    {
        maxSanityLevel = sanityLevel;
        maxHungerLevel = hungerLevel;
        maxHumidityLevel = humidityLevel;
        maxHealtlevel = healtLevel;
    }

    private void Update()
    {
        timeToCheckIfIGetHitted += UnityEngine.Time.deltaTime;
        
        if(Input.GetKey(KeyCode.F))
        {
            if (timeToCheckIfIGetHitted > debounceTimeToGetAnotherHit)
            {
                timeToCheckIfIGetHitted = 0;
                
                int damageTaken = 10;
                TakeHit(damageTaken);
                var percentageCurrenteLife = CalculatePercentageOfLife();
            
                PlayerUIHandler.Instance.ChangeUIOfLife(percentageCurrenteLife);
            }
        }
        
    }
    
    private int CalculatePercentageOfLife()
    {
        return (int)Math.Floor((healtLevel / maxHealtlevel) * 100);
    }

    /// <summary>
    /// Hunger consuming and sanity
    /// </summary>
    private void StartBasicRoutine()
    {
        var loseStatsCorroutine = nameof(LoseStatsUnderSomeConditions);
        StartCoroutine(loseStatsCorroutine);
    }

    /// <summary>
    /// Every player lose food meter over the time...
    /// </summary>
    /// <returns></returns>
    private IEnumerator LoseStatsUnderSomeConditions()
    {
        while(thePlayerItsAlive)
        {
            yield return new WaitForSeconds(Time.Instace.SECONDS_IN_A_MINUTE);//Change if u need the time pass more quickly
            FoodCalc();
            SanityCalc();
        }
    }

    private void FoodCalc()
    {
        if(hungerConsume == 0)
        {
            hungerLevel -= 1;
            Debug.Log($"Hunger level: {hungerLevel}");
        }
        else
        {
            hungerLevel -= hungerConsume;
        }
    }

    private void SanityCalc()
    {
        if(sanityConsume == 0)
        {
            sanityLevel -= 1;
            Debug.Log($"Sanity level: {sanityLevel}");
        }
        else
        {
            sanityLevel -= sanityConsume;
        }
    }

    private void SetTemperatureLevel()
    {

    }

    public void OnPlayerChangeStats()
    {
        playerStatsDelegate?.Invoke(this);
    }

    public float TakeHit(float damage)
    {
        healtLevel -= damage;
        return healtLevel;
    }

}
