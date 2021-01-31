using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Application.CoreEntities;
using Application.Visual;
using Application.CreatingEditingCards;

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
