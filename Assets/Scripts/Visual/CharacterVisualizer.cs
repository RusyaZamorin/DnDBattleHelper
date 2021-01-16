using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Core;
using Calculator;

public class CharacterVisualizer : MonoBehaviour
{
    public Character Character;

    [SerializeField] public TMP_Text NumberInSequenceField;

    [SerializeField] private TMP_InputField _maxHitPointsField;
    [SerializeField] private TMP_InputField _hitPointsField;
    [SerializeField] private TMP_InputField _bonusHitPointsField;
    [SerializeField] private TMP_InputField _armorClassField; 
    [SerializeField] private TMP_InputField _initiativeField;    
    [SerializeField] private TMP_InputField _nameInputField;    

    public Action OnCreate;
    public Action<CharacterVisualizer> OnDelete;
    public Action OnChangedInitiative;
    public Action<CharacterVisualizer> OnMoveLeft;
    public Action<CharacterVisualizer> OnMoveRight;

    #region Change/Set specifications
    public void ChangeMaxHitPoints(int changeValue) => Character.MaxHitPoints += changeValue;
    public void ChangeHitPoints(int changeValue) => Character.HitPoints += changeValue;
    public void ChangeBonusHitPoints(int changeValue) => Character.BonusHitPoints += changeValue;
    public void ChangeInitiative(int changeValue)
    {
        Character.Initiative += changeValue;
        OnChangedInitiative?.Invoke();
    }
    public void ChangeArmorClass(int changeValue) => Character.ArmorClass += changeValue;

    public void Init()
    {
        if(Character == null)
            Character = new Character();

        Character.OnChangedMaxHitPoints += UpdateMaxHitPoints;
        Character.OnChangedHitPoints += UpdateHitPoints;
        Character.OnChangedBonusHitPoints += UpdateBonusHitPoints;
        Character.OnChangedArmorClass += UpdateArmorClass;
        Character.OnChangedInitiative += UpdateInitiative;
        Character.OnChangedName += UpdateName;

        UpdateMaxHitPoints(Character.MaxHitPoints);
        UpdateHitPoints(Character.HitPoints);
        UpdateBonusHitPoints(Character.BonusHitPoints);
        UpdateArmorClass(Character.ArmorClass);
        UpdateInitiative(Character.Initiative);
        UpdateName(Character.Name);

        OnCreate?.Invoke();
    }

    public void Delete() => OnDelete?.Invoke(this);   
    
    public void MoveLeft() => OnMoveLeft?.Invoke(this);

    public void MoveRight() => OnMoveRight?.Invoke(this);

    public void SetMaxHitPoints(string newValue) => Character.MaxHitPoints = (int)ReverseNotationConverter.Calculate(newValue);

    public void SetHitPoints(string newValue) => Character.HitPoints = (int)ReverseNotationConverter.Calculate(newValue);

    public void SetBonusHitPoints(string newValue) => Character.BonusHitPoints = (int)ReverseNotationConverter.Calculate(newValue);

    public void SetInitiative(string newValue)
    {
        Character.Initiative = (int)ReverseNotationConverter.Calculate(newValue);
        OnChangedInitiative?.Invoke();
    }

    public void SetArmorClass(string newValue) => Character.ArmorClass = (int)ReverseNotationConverter.Calculate(newValue);
    
    public void SetName(string newName) => Character.Name = newName;
    #endregion

    #region Fields Update
    private void UpdateMaxHitPoints(int currentValue) => _maxHitPointsField.text = currentValue.ToString();

    private void UpdateHitPoints(int currentValue) => _hitPointsField.text = currentValue.ToString();

    private void UpdateBonusHitPoints(int currentValue) => _bonusHitPointsField.text = currentValue.ToString();

    private void UpdateArmorClass(int currentValue) => _armorClassField.text = currentValue.ToString();

    private void UpdateInitiative(int currentValue) => _initiativeField.text = currentValue.ToString();

    private void UpdateName(string currentValue) => _nameInputField.text = currentValue;
    #endregion

    private void Start()
    {
        Init();       
    }   
}
