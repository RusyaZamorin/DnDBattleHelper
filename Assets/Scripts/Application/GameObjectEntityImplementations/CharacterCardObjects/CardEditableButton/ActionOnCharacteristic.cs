using Application.CoreEntities;
using CharacteristicsCalculator;

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
        
        public void SetCharacteristicValue(Character character, double value)
        {
            character.SetCharacteristicValue(CharacteristicName, Function.Calculate(value, character));
        }
    }
}

