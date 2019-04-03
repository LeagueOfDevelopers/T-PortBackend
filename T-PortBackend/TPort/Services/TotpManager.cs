using System;
using System.Collections.Generic;
using AspNetCore.Totp;
using AspNetCore.Totp.Interface;
using TPort.Domain.Exceptions;
using TPort.Infrastructure.DataAccess;
using TPort.Services;

namespace TPortApi.Security
{
    public class TotpManager : ITotpManager
    {
        public TotpManager(ITotpGenerator totpGenerator, string secretKey, int totpTokenLifetimeInSeconds, ITotpTokenRepository totpTokenRepository)
        {
            _totpGenerator = totpGenerator ?? throw new ArgumentNullException(nameof(totpGenerator));
            _secretKey = secretKey ?? throw new ArgumentNullException(nameof(secretKey));
            _totpTokenLifetimeInSeconds = totpTokenLifetimeInSeconds;
            _totpTokenRepository = totpTokenRepository;
        }

        public int GenerateToken(string phoneNumber)
        {
            var token = _totpGenerator.Generate(_secretKey);
            _totpTokenRepository.SaveToken(phoneNumber, token);
            return token;
        }

        public bool ValidateToken(string phoneNumber, int token)
        {
            return true;
            var existingToken = _totpTokenRepository.GetToken(phoneNumber);
            if (existingToken == 0) throw new UnregisteredPhoneNumberException();
            if (existingToken != token) throw new InvalidTokenException();
            var totpValidator = new TotpValidator(_totpGenerator);
            return totpValidator.Validate(_secretKey, token, _totpTokenLifetimeInSeconds);
        }


        private readonly ITotpTokenRepository _totpTokenRepository;
        private readonly ITotpGenerator _totpGenerator;
        private readonly string _secretKey;
        private readonly int _totpTokenLifetimeInSeconds;

    }
}