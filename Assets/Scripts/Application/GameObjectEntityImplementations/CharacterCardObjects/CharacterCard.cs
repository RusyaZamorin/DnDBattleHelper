using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Application.CoreEntities;

namespace Application.GameObjectEntityImplementations
{
    public class CharacterCard : MonoBehaviour
    {
        public List<CharacteristicPanel> CharacteristicPanels = new List<CharacteristicPanel>();

        [SerializeField] Transform _characteristicPanelsContainer;
        [SerializeField] GameObject _characteristicPanelPrefab;
        [SerializeField] TMP_InputField _nameInputField;
        [SerializeField] TMP_Text _indexTextField;

        private Character _character;

        public event Action<CharacterCard> OnDelete;

        public void Init(Character character)
        {
            _character = character;

            foreach (var characteristic in _character.Characteristics)
            {
                var characteristicPanel = Instantiate(_characteristicPanelPrefab, _characteristicPanelsContainer).
                    GetComponent<CharacteristicPanel>();

                CharacteristicPanels.Add(characteristicPanel);

                characteristicPanel.Init(characteristic);
            }

            UpdateName();
            UpdateIndex();

            character.OnChangedName += (Character Character) => UpdateName();
            character.OnChangedIndex += UpdateIndex;
        }

        public void SetName(string value) => _character.Name = value;

        public void ChangeCharacter(Character character)
        {
            for(int i = 0; i < _characteristicPanelsContainer.childCount; i++)
            {
                Destroy(_characteristicPanelsContainer.GetChild(i).gameObject);
            }

            Init(character);            
        }

        public Character GetCharacter()
        {
            return _character;
        }

        public void Delete()
        {
            OnDelete?.Invoke(this);
        }

        private void UpdateName() => _nameInputField.text = _character.Name;

        private void UpdateIndex() => _indexTextField.text = ParseIndex();

        private string ParseIndex()
        {
            return _character.Index == 0 ? "" : (_character.Index + 1).ToString();
        }
    }
}

