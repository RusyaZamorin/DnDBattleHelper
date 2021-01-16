using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class CharacterVisualizatorCreater : MonoBehaviour
{
    [SerializeField] private GameObject _characterVisualizerPrefab;
    [SerializeField] private SequenceCharacterMovesMonobeh _sequenceCharactersMoves;
    [SerializeField] private CharacterVisualizer _editableCharacterVisualizer;
    [SerializeField] private Transform _cardsContainerTransform;

    public void CreateCharacterVisualizer()
    {
        var newCharacterVisualizer = Instantiate(_characterVisualizerPrefab, _cardsContainerTransform, false)
            .GetComponent<CharacterVisualizer>();

        newCharacterVisualizer.Character = _editableCharacterVisualizer.Character.Copy();
        newCharacterVisualizer.Init();

        _sequenceCharactersMoves.AddCharacterVisualizer(newCharacterVisualizer);
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
