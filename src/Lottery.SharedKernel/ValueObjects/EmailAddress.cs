namespace Lottery.SharedKernel.ValueObjects
{
    public record EmailAddress(string Value)
    {
        public override string ToString()
        {
            return Value.ToString();
        }

        public static implicit operator EmailAddress(string address)
        {
            return new EmailAddress(address);
        }
    }
}
