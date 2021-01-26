namespace Core
{
    public class CharacteristicInt : Characteristic
    {
        public CharacteristicInt(string name) : base(name) { }

        protected override void SetValue(double value)
        {
            base.SetValue((int)value);
        }

        protected override double GetValue()
        {
            return base.GetValue();
        }
    }
}


