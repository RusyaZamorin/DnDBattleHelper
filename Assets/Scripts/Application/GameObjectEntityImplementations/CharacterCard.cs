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

        public void Init(Character character)
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

        private void UpdateName() => _nameInputField.text = _character.Name;

        private void UpdateIndex() => _indexTextField.text = ParseIndex();

        private string ParseIndex()
        {
            if (_character.Index == 0)
                return "";
            else
                return (_character.Index).ToString();
        }
    }
}

