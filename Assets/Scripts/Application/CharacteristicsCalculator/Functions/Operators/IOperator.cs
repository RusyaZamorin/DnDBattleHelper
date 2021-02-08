using Application.CoreEntities;

namespace CharacteristicsCalculator.Operators
{
    public interface IOperator 
    {
        IOperator LeftOperand { get; set; }
        IOperator RightOperand { get; set; }
        string Symbol { get; }


        double GetValue();

        void SetX(double x);

        void SetCharacter(Character character);

        IOperator Copy();
    }
}

