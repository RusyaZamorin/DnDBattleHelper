using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.Visual;
using Application.CoreEntities;

namespace Application.CreatingEditingCards
{
    public class CharacterCardCreater : MonoBehaviour
    {
        [SerializeField] private GameObject _cardPrefab;
        [SerializeField] private Transform _cardsContainerTransform;

        private CharacterData _characterTemplate;        

        public void CreateCard()
        {
            var cardObject = Instantiate(_cardPrefab, _cardsContainerTransform);
            CharacterCard characterCard = cardObject.GetComponent<CharacterCard>();

            CharacterData newCharacter = _characterTemplate;

            characterCard.Init(_characterTemplate);
        }

        private void Start()
        {
            _characterTemplate = new CharacterData("name");
            _characterTemplate.Characteristics.Add( new CharacteristicInt("initiative"));
        }
    }
}

