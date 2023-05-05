using Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Physics;

namespace Hudossay.Asteroids.EngineIndependent.Assets.Scripts.EngineIndependent.Weapons
{
    public class AmmoProvider : IAmmoProvider
    {
        private readonly int _maximumCharges;
        private int _initialAvailableCharges;
        private int _availableCharges;

        private readonly ITimer _timerForCooldown;
        private readonly ITimer _timerForCharges;
        private readonly float _timeShotCooldown;
        private readonly float _timeToGainCharge;

        public int AvailableCharges => _availableCharges;
        public int MaximumCharges => _maximumCharges;
        public float RemainingCooldownTime => _timerForCooldown.RemainingTime;
        public float RemainingNextChargeTime => _timerForCharges.RemainingTime;
        public bool IsReadyToUseCharge => _timerForCooldown.IsFinished && _availableCharges > 0;


        public AmmoProvider(ITimer timerForCooldown, ITimer timerForCharges, float timeShotCooldown, float timeToGainCharge, int maximumCharges, int initialCharges)
        {
            _maximumCharges = maximumCharges;
            _initialAvailableCharges = initialCharges;
            _timerForCooldown = timerForCooldown;
            _timerForCharges = timerForCharges;
            _timeShotCooldown = timeShotCooldown;
            _timeToGainCharge = timeToGainCharge;

            Reset();
        }


        public bool TryUseCharge()
        {
            if (!IsReadyToUseCharge)
                return false;

            if (AvailableCharges >= MaximumCharges)
                _timerForCharges.StartCountdown(_timeToGainCharge);

            _availableCharges -= 1;
            _timerForCooldown.StartCountdown(_timeShotCooldown);

            return true;
        }


        public void Update(float time)
        {
            _timerForCharges.Update(time);
            _timerForCooldown.Update(time);

            AccountTimeToGainCharge();
        }


        public void Reset()
        {
            _timerForCooldown.StartCountdown(0f);
            _timerForCharges.StartCountdown(0f);
            _availableCharges = _initialAvailableCharges;
        }


        private void AccountTimeToGainCharge()
        {
            if (!_timerForCharges.IsFinished || _availableCharges >= _maximumCharges)
                return;

            _availableCharges++;
            _timerForCharges.StartCountdown(_timeToGainCharge);
        }
    }
}
