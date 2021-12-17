using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seassons : MonoBehaviour
{
    private int daysInWinter;
    private int daysInSummer;
    private int daysInAutumn;
    private int daysInSpring;

    private ESeassonType actualSeason;

    private int actualDay = 0;
    private int dayInsideOfTheSeasson = 0;

    public static Seassons Instace { get; private set; }

    void Awake()
    {
        daysInAutumn = 10;
        daysInSummer = 10;
        daysInWinter = 10;
        daysInSpring = 10;

        actualSeason = ESeassonType.Autumn;

        Instace = this;
    }

    void Start()
    {
    }

    void Update()
    {
        
    }

    private int checkWhatSeasonIs()
    {
        if(actualSeason == ESeassonType.Autumn)
        {
            return daysInAutumn;
        }
        if (actualSeason == ESeassonType.Spring)
        {
            return daysInSpring;
        }
        if (actualSeason == ESeassonType.Winter)
        {
            return daysInWinter;
        }
        if (actualSeason == ESeassonType.Summer)
        {
            return daysInSummer;
        }

        return 0;
    }

    private void AdvanceForNextSeason()
    {
        Debug.Log($"Old season: {actualSeason.ToString()}");

        if (actualSeason == ESeassonType.Autumn)
        {
            actualSeason = ESeassonType.Winter;
            return;
        }

        if (actualSeason == ESeassonType.Winter)
        {
            actualSeason = ESeassonType.Spring;
            return;
        }

        if (actualSeason == ESeassonType.Spring)
        {
            actualSeason = ESeassonType.Summer;
            return;
        }

        if (actualSeason == ESeassonType.Summer)
        {
            actualSeason = ESeassonType.Autumn;
            return;
        }

    }

    public void AdvanceOneDay()
    {
        if(dayInsideOfTheSeasson <= checkWhatSeasonIs())
        {
            actualDay += 1;
            dayInsideOfTheSeasson += 1;

            Debug.Log($"Today it's: {actualDay}");
        }
        else
        {
            actualDay += 1;
            dayInsideOfTheSeasson = 0;

            AdvanceForNextSeason();
            Debug.Log($"Today it's: {actualDay}");
        }
    }
}
