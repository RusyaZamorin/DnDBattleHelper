using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Application.CoreEntities
{
    public class CharacterData
    {
        public static List<CharacterData> AllCharactersData = new List<CharacterData>();       
        private string _name = null;
        private int _index = 0;
        private List<Characteristic> _characteristics = new List<Characteristic>();

        public Action OnChangedName;
        public Action OnChangedIndex;
        public Action OnDelete;

        public CharacterData(string name)
        {
            Name = name;
            Index = 0;

            AddCharacterToAllCharacteristic(this);
        }

        public int Index {
            get
            {
                return _index;
            }
            private set
            {
                _index = value;
                OnChangedIndex?.Invoke();
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == null)
                    _name = value;
                else if (_name != value)
                {
                    HandleRanameCharacteristic(this, value);
                    _name = value;
                }
                    
                
                OnChangedName?.Invoke();      
            }
        }
        public List<Characteristic> Characteristics { get => _characteristics; }
        
        public void SetCharacteristicValue(string characteristicName, double value)
        {
            _characteristics.Find(characteristic => characteristic.Name == characteristicName).Value = value;
        }

        public double GetCharacteristicValue(string characteristicName)
        {
            return _characteristics.Find(characteristic => characteristic.Name == characteristicName).Value;
        }

        public void Delete()
        {
            RemoveCharacterFromAllCharacteristic(this);

            OnDelete?.Invoke();
        }

        private static void AddCharacterToAllCharacteristic(CharacterData character)
        {
            if (AllCharactersData.Contains(character))
                return;
            
            var charactersWithSameName = AllCharactersData.FindAll(c => c.Name == character.Name);
            if (charactersWithSameName.Count != 0)
            {
                charactersWithSameName.Sort((x, y) => y.Index.CompareTo(x.Index));
                character.Index = charactersWithSameName[0].Index + 1;
            }            

            AllCharactersData.Add(character);
        }

        private static void RemoveCharacterFromAllCharacteristic(CharacterData character)
        {
            if (AllCharactersData.Contains(character) == false)
                return;

            AllCharactersData.Remove(character);

            var characters = AllCharactersData.
                    FindAll(c => (c.Name == character.Name) && (c.Index > character.Index));            
            foreach (CharacterData c in characters)
                c.Index = c.Index - 1;
        }

        private static void HandleRanameCharacteristic(CharacterData character, string newName)
        {
            var charactersWithOldName = AllCharactersData.
                    FindAll(c => (c.Name == character.Name) && (c.Index > character.Index));
            foreach (CharacterData c in charactersWithOldName)
                c.Index -= 1;            

            var charactersWithNewName = AllCharactersData.FindAll(c => c.Name == newName);
            if (charactersWithNewName.Count != 0)
            {
                charactersWithNewName.Sort((x, y) => y.Index.CompareTo(x.Index));
                character.Index = charactersWithNewName[0].Index + 1;
            }
            else
                character.Index = 0;            
        }
    }
}


