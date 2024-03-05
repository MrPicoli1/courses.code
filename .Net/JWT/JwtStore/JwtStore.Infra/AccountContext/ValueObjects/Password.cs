using JwtStore.Infra.SharedContext.ValueObjects;

namespace JwtStore.Infra.AccountContext.ValueObjects
{
    public class Password :ValueObject
    {
        private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
        private const string Special = "!@#$%ˆ&*(){}[];";

        public string Hash { get; } = string.Empty;
        public string ResetCode { get; } = Guid.NewGuid().ToString("N")[..8].ToUpper();



    }
}
