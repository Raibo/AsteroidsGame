namespace Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces
{
    public interface IAmmoProvider
    {
        public int AvailableCharges { get; }
        public int MaximumCharges { get; }
        public float RemainingNextChargeTime { get; }
        public float RemainingCooldownTime { get; }
        public bool IsChargeReady { get; }

        public bool TryUseCharge();
        public void Update(float time);
    }
}
