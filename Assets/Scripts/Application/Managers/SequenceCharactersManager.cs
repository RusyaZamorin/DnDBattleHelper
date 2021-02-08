using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;
using Application.GameObjectEntityImplementations;

namespace Application.Managers
{
    public class SequenceCharactersManager : MonoBehaviour
    {
        [SerializeField] private Transform __cardsContainerTransform;
        
        private SequenceCharacters _sequenceCharacters;
        private Dictionary<Character, CharacterCard> _characterToCardDictionary = new Dictionary<Character, CharacterCard>();

        public void Init(SequenceCharacters sequenceCharacters)
        {
            _sequenceCharacters = sequenceCharacters;

            _sequenceCharacters.OnSorted += UpdateCards;            
        }

        public void AddCard(CharacterCard characterCard)
        {
            _characterToCardDictionary.Add(characterCard.GetCharacter(), characterCard);

            _sequenceCharacters.AddCharacter(characterCard.GetCharacter());

            characterCard.OnDelete += DeleteCard;

            UpdateCards();
        }

        public void DeleteCard(CharacterCard characterCard)
        {            
            _characterToCardDictionary.Remove(characterCard.GetCharacter());

            Character character = characterCard.GetCharacter();            
            _sequenceCharacters.DeleteCharacter(character);

            Destroy(characterCard.gameObject);            
        }

        public void ClearCards()
        {
            
        }

        public Transform GetCardsContainerTransform()
        {
            return __cardsContainerTransform;
        }

        private void UpdateCards()
        {
            int index = 0; 
            foreach(Character character in _sequenceCharacters.GetItems())
            {
                _characterToCardDictionary[character].transform.SetSiblingIndex(index);
                index++;
            }
        }       
    }
}

