using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    private int damageMonster;
    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.Instance.playerStatsDelegate += HittingThePlayer;
    }

    private void HittingThePlayer(PlayerStats playerStats)
    {
        playerStats.TakeHit(damageMonster);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            PlayerStats.Instance.OnPlayerChangeStats();
        }
    }
}
