using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Application.CoreEntities
{
    public class SequenceCharacters 
    {
        public bool AutoSort = true;
        public SortTypes SortType = SortTypes.RightToLeft;
        public string NameCharacteristicForSort;
        public enum SortTypes
        {
            RightToLeft,
            LeftToRight
        }

        public List<CharacterData> Sequence = new List<CharacterData>();

        public event Action OnSorted;

        public void Sort()
        {
            if (SortType == SortTypes.RightToLeft)
                Sequence.Sort((x, y) => y.GetCharacteristicValue(NameCharacteristicForSort).
                    CompareTo(x.GetCharacteristicValue(NameCharacteristicForSort)));

            else if (SortType == SortTypes.LeftToRight)
                Sequence.Sort((x, y) => x.GetCharacteristicValue(NameCharacteristicForSort).
                    CompareTo(y.GetCharacteristicValue(NameCharacteristicForSort)));

            OnSorted?.Invoke();
        }

        public void AddCharacter(CharacterData character)
        {
            Sequence.Add(character);            

            if (AutoSort == true)
                Sort();
        }

        public void DeleteCharacter(CharacterData character)
        {
            if (Sequence.Contains(character))
                Sequence.Remove(character);
        }

        public void MoveCharacterLeft(CharacterData character)
        {
            int currentIndex = Sequence.IndexOf(character);
            if (currentIndex <= 0)
                return;

            Sequence.Remove(character);
            Sequence.Insert(currentIndex - 1, character);
        }

        public void MoveCharacterRight(CharacterData character)
        {
            int currentIndex = Sequence.IndexOf(character);
            if (currentIndex >= Sequence.Count - 1)
                return;

            Sequence.Remove(character);
            Sequence.Insert(currentIndex + 1, character);
        }
 
    }
}


