using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Lottery.CrossCutting.FileParser
{
    public class FileParser
    {
        private readonly Stream _stream;

        public FileParser(Stream stream)
        {
            this._stream = stream;
        }

        public IEnumerable<Participant> GetRows()
        {
            using var reader = new StreamReader(_stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Read();
            csv.ReadHeader();
            while (csv.Read())
            {
                var record = new Participant
                {
                    Name = csv.GetField("Name"),
                    FirstName = csv.GetField("First Name"),
                    LastName = csv.GetField("Last Name"),
                    Mail = csv.GetField("Email"),
                    Status = csv.GetField("Status"),
                    Action = csv.GetField("Action"),
                    Entries = csv.GetField("Entries"),
                    Details = csv.GetField("Details"),
                    City = csv.GetField("City"),
                    Region = csv.GetField("Region"),
                    Country = csv.GetField("Country"),
                    When = csv.GetField<DateTime>("When"),
                    Facebook = csv.GetField("Facebook"),
                    Instagram = csv.GetField("Instagram"),
                    Twitter = csv.GetField("Twitter"),
                    Youtube = csv.GetField("Youtube")
                };
                yield return record;
            }
        }
    }

    public record Participant
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mail { get; set; }
        public string Status { get; set; }
        public string Action { get; set; }
        public string Entries { get; set; }
        public string Details { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public DateTime When { get; set; }
        public string Facebook { get; set; }
        public string Instagram { get; set; }
        public string Twitter { get; set; }
        public string Youtube { get; set; }
    }
}
