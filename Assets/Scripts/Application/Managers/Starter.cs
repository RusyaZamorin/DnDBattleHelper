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

        private SequenceCharacters _sequenceCharacters;

        private void Init()
        {
            _sequenceCharacters = new SequenceCharacters();


            _characterCardCreater.Init();
        }

        private void Awake()
        {
            Init();
        }

    }

}
