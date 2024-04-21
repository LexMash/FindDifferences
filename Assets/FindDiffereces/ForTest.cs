using AppodealAds.Unity.Api;
using FindDiffereces.Data;
using FindDiffereces.GamePlay;
using FindDiffereces.GamePlay.Time;
using FindDiffereces.Infrastracture;
using FindDiffereces.Infrastracture.Ads;
using FindDiffereces.Infrastracture.Purchase;
using FindDiffereces.UI;
using FindDifferences.UI;
using TMPro;
using UnityEngine;

namespace FindDifferences
{
    public class ForTest : MonoBehaviour
    {
        public TimerWidget _widget;
        TimeController controller;

        private void Start()
        {
            var timer = new Timer();
            controller = new TimeController(timer, _widget, 10f);
            controller.Start();
        }

        private void Update()
        {
            controller.Tick();
        }
    }
}
