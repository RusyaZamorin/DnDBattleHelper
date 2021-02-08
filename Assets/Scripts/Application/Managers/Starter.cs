using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;
using Application.GameObjectEntityImplementations;

namespace Application.Managers
{
    public class Starter : MonoBehaviour
    {
        [SerializeField] CharacterCardCreater _characterCardCreater;
        [SerializeField] SequenceCharactersManager _sequenceCharactersManager;

        private SequenceCharacters _sequenceCharacters;

        private void Init()
        {
            _sequenceCharacters = new SequenceCharacters();            
            _sequenceCharacters.NameCharacteristicForSort = "Initiative"; // TEMP

            _sequenceCharactersManager.Init(_sequenceCharacters);

            _characterCardCreater.Init(_sequenceCharactersManager);
        }

        private void Awake()
        {
            Init();            
        }        
    }

}
