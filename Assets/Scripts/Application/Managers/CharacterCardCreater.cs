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
        [SerializeField] private Transform _cardsContainerTransform;
        [SerializeField] private CharacterCard _editableCard;
        [SerializeField] private Sprite _initiativeIcon;
        [SerializeField] private Sprite _hpIcon;        

        private Character _characterTemplate;        

        [ContextMenu("CreateCard")]
        public void CreateCard()
        {
            var cardObject = Instantiate(_cardPrefab, _cardsContainerTransform);
            CharacterCard characterCard = cardObject.GetComponent<CharacterCard>();

            Character newCharacter = _characterTemplate.Copy();

            characterCard.Init(newCharacter);
        }

        public void SetTemplateCharacter(Character character)
        {
            _characterTemplate = character;
            _editableCard.ChangeCharacter(_characterTemplate);
        }

        public void Init()
        {
            // Template init with creating character template
            string initiative = "Iitiative";
            string hp = "HP";
            _characterTemplate = new Character("name");

            var charact1 = new CharacteristicInt(hp);
            charact1.Value = 10;
            charact1.Icon = _hpIcon;
            _characterTemplate.Characteristics.Add(charact1);

            var charact2 = new CharacteristicInt(initiative);
            charact2.Value = 0;
            charact2.Icon = _initiativeIcon;
            _characterTemplate.Characteristics.Add(charact2);

            _editableCard.Init(_characterTemplate);
        }        
    }
}

