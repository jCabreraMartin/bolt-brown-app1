using System.Collections.Generic;
using TimeTracking.Data;
using TimeTracking.Data.Models;

namespace TimeTracking.Business
{
    public class ChargeAccountService
    {
        private readonly ChargeAccountRepository _chargeAccountRepository;

        public ChargeAccountService()
        {
            _chargeAccountRepository = new ChargeAccountRepository();
        }

        public ChargeAccountService(ChargeAccountRepository chargeAccountRepository)
        {
            _chargeAccountRepository = chargeAccountRepository;
        }

        public List<ChargeAccount> GetActiveAccounts()
        {
            return _chargeAccountRepository.GetAll();
        }

        public ChargeAccount GetById(int id)
        {
            return _chargeAccountRepository.GetById(id);
        }

        public OperationResult AddChargeAccount(string code, string description)
        {
            if (string.IsNullOrWhiteSpace(code))
                return new OperationResult(false, "Code is required.");

            if (string.IsNullOrWhiteSpace(description))
                return new OperationResult(false, "Description is required.");

            if (code.Length > 20)
                return new OperationResult(false, "Code cannot exceed 20 characters.");

            var existing = _chargeAccountRepository.GetByCode(code);
            if (existing != null)
                return new OperationResult(false, "A charge account with that code already exists.");

            var account = new ChargeAccount
            {
                Code = code.Trim().ToUpper(),
                Description = description.Trim(),
                Active = true
            };

            int id = _chargeAccountRepository.Insert(account);
            account.Id = id;

            return new OperationResult(true, "Charge account created successfully.");
        }
    }

    public class OperationResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }

        public OperationResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
