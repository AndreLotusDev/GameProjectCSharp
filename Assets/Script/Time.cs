using System.Collections;
using UnityEngine;

public class Time : MonoBehaviour
{
    public static Time Instace { get; set; }

    [SerializeField]
    private int? secondsPerDay; //If u dont feel the minutes u can use this option just for test
    [SerializeField]
    private int? numberOfMinutesPerDay;

    public int SECONDS_IN_A_MINUTE = 1; // U can chage for testing purpouse

    private void Awake()
    {
        Instace = this;
        
    }

    private void Start()
    {
        StartCoroutine(nameof(RunADayPerSpecifyQuantityOfMinutes), numberOfMinutesPerDay ?? 1);
    }

    void Update()
    {
        
    }

    //FOR DEBUGGING PURPOUSE
    //private IEnumerator RunADayPerSpecifyQuantityOfSeconds(int seconds)
    //{
    //    while (true)
    //    {
    //        Seassons.Instace.AdvanceOneDay();
    //        yield return new WaitForSeconds(seconds);
    //    }
    //}

    private IEnumerator RunADayPerSpecifyQuantityOfMinutes(int minutes)
    {
        while (true)
        {
            Seassons.Instace.AdvanceOneDay();
            yield return new WaitForSecondsRealtime(minutes * SECONDS_IN_A_MINUTE);
        }
    }
}
