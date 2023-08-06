using GameProject3.ScriptableObjects;

namespace GameProject3.Abstracts.Combats
{
    public interface IAttackType
    {
        void AttackAction();
        AttackSO AttackInfo { get; }
    }
}

