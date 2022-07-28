using Creatures.States;

namespace Creatures.Units.States
{
    public abstract class UnitStateTransition : StateTransiton
    {
        protected IUnit unit = null;
        public override void Init(params object[] initializationParams)
        {
            unit = new ParamsToTypeConverter<IUnit>(initializationParams).Get();
        }
    } 
}

