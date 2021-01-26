using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

namespace Core
{
    public class SequenceMovesManager 
    {
        public bool AutoSort = true;
        public SortTypes SortType = SortTypes.RightToLeft;
        public enum SortTypes
        {
            RightToLeft,
            LeftToRight
        }

        public List<Character> Sequence = new List<Character>();        
        
        public event Action OnSortedByInitiative;        

        public void SortByInitiative()
        {
            if(SortType == SortTypes.RightToLeft)
                Sequence.Sort((x,y) => y.Initiative.CompareTo(x.Initiative));
            else if(SortType == SortTypes.LeftToRight)
                Sequence.Sort((x, y) => x.Initiative.CompareTo(y.Initiative));            

            OnSortedByInitiative?.Invoke();
        }

        public void AddCharacter(Character character)
        {
            Sequence.Add(character);            
            character.OnChangedInitiative += (int initiative) => HandleInitiativeChange();            

            if (AutoSort == true) 
                SortByInitiative();
        }

        public void DeleteCharacter(Character character)
        {
            if(Sequence.Contains(character))
                Sequence.Remove(character);                 
        }        

        public void MoveCharacterLeft(Character character)
        {
            int currentIndex = Sequence.IndexOf(character);
            if (currentIndex <= 0)
                return;

            Sequence.Remove(character);
            Sequence.Insert(currentIndex - 1, character);            
        }

        public void MoveCharacterRight(Character character)
        {
            int currentIndex = Sequence.IndexOf(character);
            if (currentIndex >= Sequence.Count - 1)
                return;

            Sequence.Remove(character);
            Sequence.Insert(currentIndex + 1, character);            
        }
        
        private void HandleInitiativeChange()
        {
            if (AutoSort == true)
                SortByInitiative();            
        }              

    }
}

