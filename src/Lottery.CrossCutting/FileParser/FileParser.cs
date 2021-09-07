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
                (
                    Name: csv.GetField("Name"),
                    FirstName: csv.GetField("First Name"),
                    LastName: csv.GetField("Last Name"),
                    Mail: csv.GetField("Email"),
                    Status: csv.GetField("Status"),
                    Action: csv.GetField("Action"),
                    Entries: csv.GetField("Entries"),
                    Details: csv.GetField("Details"),
                    City: csv.GetField("City"),
                    Region: csv.GetField("Region"),
                    Country: csv.GetField("Country"),
                    When: csv.GetField<DateTime>("When"),
                    Facebook: csv.GetField("Facebook"),
                    Instagram: csv.GetField("Instagram"),
                    Twitter: csv.GetField("Twitter"),
                    Youtube: csv.GetField("Youtube")
                );
                yield return record;
            }
        }
    }

    public record Participant(string Name,
                              string FirstName,
                              string LastName,
                              string Mail,
                              string Status,
                              string Action,
                              string Entries,
                              string Details,
                              string City,
                              string Region,
                              string Country,
                              DateTime When,
                              string Facebook,
                              string Instagram,
                              string Twitter,
                              string Youtube);
}
