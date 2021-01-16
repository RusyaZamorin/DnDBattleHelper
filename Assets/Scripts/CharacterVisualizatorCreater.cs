using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class CharacterVisualizatorCreater : MonoBehaviour
{
    [SerializeField] private GameObject _characterVisualizerPrefab;
    [SerializeField] private SequenceCharactersMoves _sequenceCharactersMoves;
    [SerializeField] private CharacterVisualizer _editableCharacterVisualizer;

    public void CreateCharacterVisualizer()
    {
        var newCharacterVisualizer = Instantiate(_characterVisualizerPrefab, _sequenceCharactersMoves.transform, false)
            .GetComponent<CharacterVisualizer>();

        newCharacterVisualizer.Character = _editableCharacterVisualizer.Character.Copy();
        newCharacterVisualizer.Init();

        _sequenceCharactersMoves.AddCharacter(newCharacterVisualizer);
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        if(_editableCharacterVisualizer == null)
            _editableCharacterVisualizer = Instantiate(_characterVisualizerPrefab, transform).GetComponent<CharacterVisualizer>();
    }
}
