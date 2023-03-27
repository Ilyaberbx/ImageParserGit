using TMPro;
using UnityEngine;

namespace UI
{
    public class ResultsCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        
        public void UpdateResultCount(int value) 
            => _text.text = "Results count: " + value;
    }
}