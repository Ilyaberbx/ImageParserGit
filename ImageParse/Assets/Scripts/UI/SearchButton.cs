using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SearchButton : MonoBehaviour
    {
        public event Action<string> OnSearched;

        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Button _button;
        
        private string _inputText;

        private void Awake()
        {
            _button.onClick.AddListener(Execute);
            _inputField.onValueChanged.AddListener(ReadInput);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Execute);
            _inputField.onValueChanged.RemoveListener(ReadInput);
        }

        private void ReadInput(string text)
            => _inputText = text;

        private void Execute()
        {
            if (string.IsNullOrEmpty(_inputText))
                return;

            OnSearched?.Invoke(_inputText);
        }
    }
}