using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.GameObjectEntityImplementations;
using Application.CoreEntities;

namespace Application.Managers
{
    public class CharacterCardCreater : MonoBehaviour
    {
        [SerializeField] private GameObject _cardPrefab;        
        [SerializeField] private CharacterCard _editableCard;
        [SerializeField] private Sprite _initiativeIcon;
        [SerializeField] private Sprite _hpIcon;        

        private Character _characterTemplate;
        private SequenceCharactersManager _sequenceCharactersManager;

        [ContextMenu("CreateCard")]
        public void CreateCard()
        {
            var cardObject = Instantiate(_cardPrefab, _sequenceCharactersManager.GetCardsContainerTransform());
            var newCard = cardObject.GetComponent<CharacterCard>();

            var newCharacter = _characterTemplate.Copy();

            newCard.Init(newCharacter);

            _sequenceCharactersManager.AddCard(newCard);
        }

        public void SetTemplateCharacter(Character character)
        {
            _characterTemplate = character;
            _editableCard.ChangeCharacter(_characterTemplate);
        }

        public void Init(SequenceCharactersManager sequenceCharactersManager)
        {
            _sequenceCharactersManager = sequenceCharactersManager;

            // Template init with creating character template
            var initiative = "Initiative";
            var hp = "HP";
            _characterTemplate = new Character("name");

            var charact1 = new CharacteristicInt(hp) {Value = 10, Icon = _hpIcon};
            _characterTemplate.Characteristics.Add(charact1);

            var charact2 = new CharacteristicInt(initiative) {Value = 0, Icon = _initiativeIcon};
            _characterTemplate.Characteristics.Add(charact2);

            _editableCard.Init(_characterTemplate);
        }        
    }
}

