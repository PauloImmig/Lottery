using Lottery.SharedKernel;
using System;
using System.Linq;

namespace Lottery.Domain.Entities
{
    public class CampaignEmailTemplate : Entity
    {
        private CampaignEmailTemplate() : base()
        {

        }

        public CampaignEmailTemplate(EmailSubject subject, EmailContent content, EmailContentPlaceholders placeholders) : base()
        {
            Subject = subject;
            Content = content;
            Placeholders = placeholders;
        }

        public EmailSubject Subject { get; }
        public EmailContent Content { get; }
        public EmailContentPlaceholders Placeholders { get; }
        public virtual Campaign Campaign { get; set; }
    }

    public class EmailSubject
    {
        private EmailSubject()
        {

        }

        public EmailSubject(string value)
        {
            if (value.Length <= 5) throw new ArgumentException("Subject should have at least 5 characters", nameof(value));
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(EmailSubject subject) => subject.Value;
        public static implicit operator EmailSubject(string value) => new(value);
    }

    public class EmailContent
    {
        private EmailContent()
        {

        }

        public EmailContent(string value)
        {
            if (value.Length <= 5) throw new ArgumentException("Content should have at least 5 characters", nameof(value));

            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return Value;
        }

        public static implicit operator string(EmailContent subject) => subject.Value;
        public static implicit operator EmailContent(string value) => new(value);
    }

    public class EmailContentPlaceholders
    {
        private EmailContentPlaceholders()
        {

        }

        public EmailContentPlaceholders(string[] value)
        {
            ValidatePlaceholders(value);

            Value = value ?? Array.Empty<string>();
        }

        private static void ValidatePlaceholders(string[] value)
        {
            bool hasRepeatedPlaceholders = value?.GroupBy(x => x).Any(x => x.Count() > 1) ?? false;
            if (hasRepeatedPlaceholders) throw new ArgumentException($"{nameof(EmailContentPlaceholders)} can't have repeated values.", nameof(value));
        }

        public EmailContentPlaceholders(string value)
        {
            Value = value.Split(",");

            ValidatePlaceholders(Value);
        }

        public string[] Value { get; }

        public override string ToString()
        {
            return string.Join(',', Value);
        }

        public static implicit operator string(EmailContentPlaceholders subject) => string.Join(',', subject.Value);
        public static implicit operator EmailContentPlaceholders(string value) => new(value.Split(","));
    }
}
