using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FindDifferences
{
    public class posTest : MonoBehaviour
    {
        public RectTransform RectTransform;
        // Update is called once per frame
        void Update()
        {
            print(RectTransform.localPosition);
        }
    }
}
