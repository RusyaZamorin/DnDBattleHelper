using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Application.CoreEntities
{
    public class SequenceCharacters 
    {
        public enum SortTypes
        {
            RightToLeft,
            LeftToRight
        }

        public bool CanAutoSort = true;
        public SortTypes SortType = SortTypes.RightToLeft;
        public string NameCharacteristicForSort;        

        private List<Character> _sequence = new List<Character>();

        public event Action OnSorted;
        public event Action OnChangedSequence;

        public void Sort()
        {
            if (SortType == SortTypes.RightToLeft)
                _sequence.Sort((x, y) => y.GetCharacteristicValue(NameCharacteristicForSort).
                    CompareTo(x.GetCharacteristicValue(NameCharacteristicForSort)));

            else if (SortType == SortTypes.LeftToRight)
                _sequence.Sort((x, y) => x.GetCharacteristicValue(NameCharacteristicForSort).
                    CompareTo(y.GetCharacteristicValue(NameCharacteristicForSort)));

            OnSorted?.Invoke();
        }

        public void AddCharacter(Character character)
        {
            _sequence.Add(character);            

            if (AutoSort == true)
                Sort();

            OnChangedSequence?.Invoke();
        }

        public void DeleteCharacter(Character character)
        {
            if (_sequence.Contains(character))
                _sequence.Remove(character);

            OnChangedSequence?.Invoke();
        }

        public void MoveCharacterLeft(Character character)
        {
            int currentIndex = _sequence.IndexOf(character);
            if (currentIndex <= 0)
                return;

            _sequence.Remove(character);
            _sequence.Insert(currentIndex - 1, character);

            OnChangedSequence?.Invoke();
        }

        public void MoveCharacterRight(Character character)
        {
            int currentIndex = _sequence.IndexOf(character);
            if (currentIndex >= _sequence.Count - 1)
                return;

            _sequence.Remove(character);
            _sequence.Insert(currentIndex + 1, character);

            OnChangedSequence?.Invoke();
        }

        public List<Character> GetItems() 
        { 
            return _sequence; 
        }
    }
}


