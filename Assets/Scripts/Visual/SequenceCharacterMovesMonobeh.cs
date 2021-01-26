using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class SequenceCharacterMovesMonobeh : MonoBehaviour
{
    private SequenceMovesManager _sequence = new SequenceMovesManager();
    private Dictionary<Character, CharacterVisualizer> _dictipnary_Characters_Visualizers = new Dictionary<Character, CharacterVisualizer>();


    public void AddCharacterVisualizer(CharacterVisualizer characterVisualizer)
    {
        _dictipnary_Characters_Visualizers.Add(characterVisualizer.Character, characterVisualizer);
        _sequence.AddCharacter(characterVisualizer.Character);

        characterVisualizer.OnMoveLeft += MoveCharacterVisualizerLeft;
        characterVisualizer.OnMoveRight += MoveCharacterVisualizerRight;
        characterVisualizer.OnDelete += DeleteCharacterVisualizer;
    }

    public void DeleteCharacterVisualizer(CharacterVisualizer characterVisualizer)
    {
        _dictipnary_Characters_Visualizers.Remove(characterVisualizer.Character);
        _sequence.DeleteCharacter(characterVisualizer.Character);

        Destroy(characterVisualizer.gameObject);
    }

    public void MoveCharacterVisualizerLeft(CharacterVisualizer characterVisualizer)
    {
        _sequence.MoveCharacterLeft(characterVisualizer.Character);
        RedrawSequence();
    }

    public void MoveCharacterVisualizerRight(CharacterVisualizer characterVisualizer)
    {
        _sequence.MoveCharacterRight(characterVisualizer.Character);
        RedrawSequence();
    }

    public void Sort() => _sequence.SortByInitiative();

    public void SetSortType(bool rightToLeft)
    {
        if (rightToLeft == true)
            _sequence.SortType = SequenceMovesManager.SortTypes.RightToLeft;
        else
            _sequence.SortType = SequenceMovesManager.SortTypes.LeftToRight;
    }

    public void SetAutoSortState(bool active) => _sequence.AutoSort = active;    

    private void RedrawSequence()
    {
        foreach(Character character in _sequence.Sequence)
        {
            int index = _sequence.Sequence.IndexOf(character);

            _dictipnary_Characters_Visualizers[character].transform.SetSiblingIndex(index);

            _dictipnary_Characters_Visualizers[character].NumberInSequenceField.text = (index + 1).ToString();
        }             
    }        

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _sequence.OnSortedByInitiative += RedrawSequence;

    }
}
