using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Core
{
    public class SequenceCharactersMoves : MonoBehaviour
    {
        public bool AutoSort = true;

        [SerializeField] private List<CharacterVisualizer> _sequence = new List<CharacterVisualizer>();
        [SerializeField] private Transform _visualizatorsContainerTransform;
        
        public event Action OnSortedByInitiative;         

        public void SortByInitiative()
        {
            _sequence.Sort((x,y) => y.Character.Initiative.CompareTo(x.Character.Initiative));

            RedrawSequence();

            OnSortedByInitiative?.Invoke();
        }

        public void AddCharacter(CharacterVisualizer character)
        {
            _sequence.Add(character);
            character.OnDelete += DeleteCharacter;
            character.OnChangedInitiative += HandleInitiativeChange;
            character.OnMoveLeft += MoveCharacterLeft;
            character.OnMoveRight += MoveCharacterRight;

            if (AutoSort == true) 
                SortByInitiative();
        }

        public void DeleteCharacter(CharacterVisualizer character)
        {
            if(_sequence.Contains(character))
                _sequence.Remove(character);

            Destroy(character.gameObject);            
        }

        public void SetAutoSort(bool state)
        {
            AutoSort = state;
            if (AutoSort == true)
                SortByInitiative();
        }

        public void MoveCharacterLeft(CharacterVisualizer character)
        {
            int currentIndex = _sequence.IndexOf(character);
            if (currentIndex <= 0)
                return;

            _sequence.Remove(character);
            _sequence.Insert(currentIndex - 1, character);

            RedrawSequence();
        }

        public void MoveCharacterRight(CharacterVisualizer character)
        {
            int currentIndex = _sequence.IndexOf(character);
            if (currentIndex >= _sequence.Count - 1)
                return;

            _sequence.Remove(character);
            _sequence.Insert(currentIndex + 1, character);

            RedrawSequence();
        }

        private void RedrawSequence()
        {
            foreach (CharacterVisualizer visualizer in _sequence)
            {
                visualizer.transform.SetSiblingIndex(_sequence.IndexOf(visualizer));
            }
        }

        private void HandleInitiativeChange()
        {
            if (AutoSort == true)
                SortByInitiative();            
        }              

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
                SortByInitiative();
        }
    }
}

