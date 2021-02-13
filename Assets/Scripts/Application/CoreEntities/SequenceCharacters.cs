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
        public bool CanAutoChangeIndices = true;

        public SortTypes SortType = SortTypes.RightToLeft;
        public string NameCharacteristicForSort;        

        private List<Character> _sequence = new List<Character>();

        public event Action OnSorted;
        public event Action OnChangedSequence;
        public event Action<Character> OnAddedCharacter;
        public event Action<Character> OnDeleteCharacter;
        public event Action OnCleared;

        public void Sort()
        {
            if (CanAutoSort == false)
                return;

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

            character.OnChangesName += ChangeIndicesWhenDeletingCharacter;
            character.OnChangedName += ChangeIndexWhenAddingCharacter;
            character.GetCharacteristic(NameCharacteristicForSort).OnChangedValue += Sort;

            Sort();

            ChangeIndexWhenAddingCharacter(character);

            OnChangedSequence?.Invoke();
            OnAddedCharacter?.Invoke(character);
        }

        public void DeleteCharacter(Character character)
        {
            OnDeleteCharacter?.Invoke(character);

            character.OnChangesName -= ChangeIndicesWhenDeletingCharacter;
            character.OnChangedName -= ChangeIndexWhenAddingCharacter;

            if (_sequence.Contains(character))
                _sequence.Remove(character);

            ChangeIndicesWhenDeletingCharacter(character);

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

        public IList GetItems() 
        { 
            return _sequence; 
        }

        public void Clear() 
        {
            foreach(var character in _sequence)
            {
                DeleteCharacter(character);
            }
            OnCleared?.Invoke();
        }

        private void ChangeIndexWhenAddingCharacter(Character character)
        {
            if (CanAutoChangeIndices == false)
                return;

            var charactersWithSameName = _sequence.FindAll(c => (c.Name == character.Name) && (c != character));
            if (charactersWithSameName.Count != 0)
            {
                charactersWithSameName.Sort((x, y) => y.Index.CompareTo(x.Index));
                character.Index = charactersWithSameName[0].Index + 1;
            }
        }

        private void ChangeIndicesWhenDeletingCharacter(Character character)
        {
            if (CanAutoChangeIndices == false)
                return;

            var characters = _sequence.FindAll(c => (c.Name == character.Name) && (c.Index > character.Index));
            foreach (Character c in characters)
                c.Index -= 1;
        }

    }
}

