using Application.CharacteristicsCalculator.Functions;
using Application.CoreEntities;

namespace Application.GameObjectEntityImplementations
{
    public class ActionOnCharacteristic
    {
        public string CharacteristicName;
        public Function Function;

        public ActionOnCharacteristic(string characteristicName)
        {
            CharacteristicName = characteristicName;
        }
        
        public void Execute(Character character, double value)
        {
            character.SetCharacteristicValue(CharacteristicName, Function.Calculate(value, character));
        }
    }
}

