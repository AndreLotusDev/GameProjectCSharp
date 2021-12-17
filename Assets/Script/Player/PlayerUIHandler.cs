using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

namespace Script.Player
{
    public class PlayerUIHandler : MonoBehaviour
    {
        public static PlayerUIHandler Instance { get; private set; }

        private Slider quantityOfLifeUI;

        public void Awake()
        {
            Instance = this;
            quantityOfLifeUI = GameObject.Find("HealtBarFather").GetComponent<Slider>();
        }

        public void ChangeUIOfLife(int percentageOfLife)
        {
            if (percentageOfLife < 0 || percentageOfLife > 100)
            {
                throw new Exception("Should be between 0 and 100, not less not more");
            }
            
            var oneToZeroCorretionOfPercentageLife = (float)percentageOfLife / 100;

            quantityOfLifeUI.value = oneToZeroCorretionOfPercentageLife;

        }
    }
}