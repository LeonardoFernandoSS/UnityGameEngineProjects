using UnityEngine;

namespace IntroductionSystem
{
    [CreateAssetMenu(fileName = "New Introduction", menuName = "Introduction")]
    public class IntroductionData : ScriptableObject
    {
        public string title;
        public bool hiddenTitle;

        [TextArea]
        public string content;
    }
}
