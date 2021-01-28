using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Application.CoreEntities;

namespace Application.Visual
{
    public class CharacterCard : MonoBehaviour
    {
        public List<CharacteristicPanel> CharacteristicPanels = new List<CharacteristicPanel>();

        [SerializeField] Transform _characteristicPanelsContainer;
        [SerializeField] GameObject _characteristicPanelPrefab;
        [SerializeField] TMP_InputField _nameInputField;
        [SerializeField] TMP_Text _indexTextField;

        private CharacterData _character;

        public void Init(CharacterData character)
        {
            _character = character;

            foreach (var characteristic in _character.Characteristics)
            {
                CharacteristicPanel characteristicPanel = Instantiate(_characteristicPanelPrefab, _characteristicPanelsContainer).
                    GetComponent<CharacteristicPanel>();

                CharacteristicPanels.Add(characteristicPanel);

                characteristicPanel.Init(characteristic);
            }

            UpdateName();
            UpdateIndex();

            character.OnChangedName += UpdateName;
            character.OnChangedIndex += UpdateIndex;
        }
        public void SetName(string name) => _character.Name = name;


        private void UpdateName() => _nameInputField.text = _character.Name;
        private void UpdateIndex() => _indexTextField.text = ParseIndex();

        private string ParseIndex()
        {
            if (_character.Index == 0)
                return "";
            else
                return (_character.Index + 1).ToString();
        }
    }
}

