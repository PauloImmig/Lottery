using Lottery.Domain.Entities;
using Lottery.SharedKernel;
using Lottery.SharedKernel.Interfaces;
using Lottery.SharedKernel.ValueObjects;
using System;
using System.Collections.Generic;

namespace Lottery.Entities.Models
{
    public class Participant : Entity, IAggregateRoot
    {
        private Participant()
        {
        }

        public Participant(string name,
                           string firstName,
                           string lastName,
                           EmailAddress mail,
                           ParticipantStatus status,
                           string action,
                           string entries,
                           string details,
                           string city,
                           string region,
                           string country,
                           DateTime when,
                           string facebook,
                           string instagram,
                           string twitter,
                           string youtube)
        {
            Name = name;
            FirstName = firstName;
            LastName = lastName;
            Mail = mail;
            Status = status;
            Action = action;
            Entries = entries;
            Details = details;
            City = city;
            Region = region;
            Country = country;
            When = when;
            Facebook = facebook;
            Instagram = instagram;
            Twitter = twitter;
            Youtube = youtube;
        }

        public string Name { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public EmailAddress Mail { get; private set; }
        public ParticipantStatus Status { get; private set; }
        public string Action { get; private set; }
        public string Entries { get; private set; }
        public string Details { get; private set; }
        public string City { get; private set; }
        public string Region { get; private set; }
        public string Country { get; private set; }
        public DateTime When { get; private set; }
        public string Facebook { get; private set; }
        public string Instagram { get; private set; }
        public string Twitter { get; private set; }
        public string Youtube { get; private set; }
        public long? LuckyNumber { get; private set; } = null;
        public Guid CampaignId { get; set; }
        public virtual Campaign Campaign { get; set; }
        public void SetLuckyNumber(long number) => LuckyNumber = number;

        public sealed class ParticipantStatus
        {
            public const string ValidValue = "VALID";
            public const string InvalidValue = "INVALID";
            public static readonly ParticipantStatus Valid = new ParticipantStatus(ValidValue);
            public static readonly ParticipantStatus Invalid = new ParticipantStatus(InvalidValue);

            public static readonly SortedList<string, ParticipantStatus> Values = new SortedList<string, ParticipantStatus>();
            private readonly string Value;

            private ParticipantStatus(string value)
            {
                this.Value = value.ToUpper();
                Values.Add(value.ToUpper(), this);
            }


            public static implicit operator ParticipantStatus(string value)
            {
                return Values[value.ToUpper()];
            }

            public static implicit operator string(ParticipantStatus value)
            {
                return value.Value;
            }
        }
    }
}
