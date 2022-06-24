using System;
namespace JRPGBattleSystem
{
    public interface IBattleState
    {
        void Start();

        void Stop();

        Enum GetEnum();
    }
}
