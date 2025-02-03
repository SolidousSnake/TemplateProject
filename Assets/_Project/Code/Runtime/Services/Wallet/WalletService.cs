using _Project.Code.Runtime.Data.Persistent;
using _Project.Code.Runtime.Data.Enum;
using System.Collections.Generic;
using System;

namespace _Project.Code.Runtime.Services.Wallet
{
    public class WalletService
    {
        private Dictionary<CurrencyType, int> _wallets = new();

        public event Action<CurrencyType, int> BalanceChanged;

        public void Initialize()
        {
            foreach (CurrencyType type in Enum.GetValues(typeof(CurrencyType)))
                if (type != CurrencyType.None)
                    _wallets[type] = 0;
        }

        public void Add(CurrencyType type, int amount)
        {
            if (type == CurrencyType.None)
                throw new ArgumentException("Currency type cannot be 'None'.", nameof(type));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to spend cannot be negative.");

            _wallets[type] += amount;
            BalanceChanged?.Invoke(type, _wallets[type]);
        }

        public bool TrySpend(CurrencyType type, int amount)
        {
            if (type == CurrencyType.None)
                throw new ArgumentException("Currency type cannot be 'None'.", nameof(type));

            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount to spend cannot be negative.");


            if (_wallets[type] < amount)
                return false;

            _wallets[type] -= amount;
            BalanceChanged?.Invoke(type, _wallets[type]);
            return true;
        }

        public int GetBalance(CurrencyType type)
        {
            if (type == CurrencyType.None)
                throw new ArgumentException("Currency type cannot be 'None'.", nameof(type));

            return _wallets.ContainsKey(type) ? _wallets[type] : 0;
        }

        public void ResetBalance()
        {
            foreach (var key in _wallets.Keys)
            {
                _wallets[key] = 0;
                BalanceChanged?.Invoke(key, 0);
            }
        }
        
        public void LoadFromProgress(PlayerProgress progress) => _wallets = new Dictionary<CurrencyType, int>(progress.Wallets);

        public void SaveToProgress(PlayerProgress progress) => progress.Wallets = new Dictionary<CurrencyType, int>(_wallets);
    }
}