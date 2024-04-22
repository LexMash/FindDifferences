using FindDifferences.Infrastracture;
using FindDifferences.UI;
using UnityEngine;

namespace FindDifferences
{
    public class ForTest : MonoBehaviour
    {
        public UIRoot _root;
        // Start is called before the first frame update
        async void Start()
        {
            var levelLoader = new LevelLoader(_root);
            await levelLoader.LoadLevel(0);
        }

    }
}
