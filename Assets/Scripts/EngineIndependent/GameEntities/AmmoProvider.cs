using Hudossay.Asteroids.Assets.Scripts.EngineIndependent.GameLogicInterfaces;

namespace Assets.Scripts.EngineIndependent.GameEntities
{
    public class AmmoProvider : IAmmoProvider
    {
        private readonly int _maximumCharges;
        private int _availableCharges;

        private readonly float _timeToGainCharge;
        private readonly float _timeShotCooldown;

        private float _remainingNextChargeTime;
        private float _remainingCooldownTime;

        private bool _isShotCooldownReady;

        public int AvailableCharges => _availableCharges;

        public int MaximumCharges => _maximumCharges;

        public float RemainingNextChargeTime => _remainingNextChargeTime;

        public float RemainingCooldownTime => _remainingCooldownTime;

        public bool IsChargeReady => _isShotCooldownReady && _availableCharges > 0;


        public AmmoProvider(float timeShotCooldown, float timeToGainCharge, int maximumCharges, int initialCharges)
        {
            _maximumCharges = maximumCharges;
            _availableCharges = initialCharges;

            _timeShotCooldown = timeShotCooldown;
            _timeToGainCharge = timeToGainCharge;

            _remainingNextChargeTime = timeToGainCharge;
            _remainingCooldownTime = timeShotCooldown;

            _isShotCooldownReady = true;
        }


        public bool TryUseCharge()
        {
            if (!IsChargeReady)
                return false;

            _availableCharges -= 1;
            _isShotCooldownReady = false;

            return true;
        }


        public void Update(float time)
        {
            AccountTimeToGainCharge(time);
            AccountTimeToNextShot(time);
        }


        private void AccountTimeToGainCharge(float time)
        {
            if (_availableCharges >= _maximumCharges)
                return;

            _remainingNextChargeTime -= time;

            if (_remainingNextChargeTime > 0f)
                return;

            _availableCharges++;
            _remainingNextChargeTime += _timeToGainCharge;

            if (_availableCharges >= _maximumCharges)
                _remainingNextChargeTime = _timeToGainCharge;
        }


        private void AccountTimeToNextShot(float time)
        {
            if (_isShotCooldownReady)
                return;

            _remainingCooldownTime -= time;

            if (_remainingCooldownTime > 0f)
                return;

            _isShotCooldownReady = true;
            _remainingCooldownTime = _timeShotCooldown;
        }
    }
}
