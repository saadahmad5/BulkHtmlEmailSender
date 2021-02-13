using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BulkHtmlEmailSender
{
    public class DistributionList
    {
        const int EMAILADDRESS = 0;
        const int NAME = 1;

        private int Count;
        private readonly List<Person> People;
        public DistributionList()
        {
            Count = 0;
            People = new List<Person>();
        }

        public void Initialize(string PathToDistributionFile)
        {
            try
            {
                using StreamReader streamReader = new StreamReader(PathToDistributionFile);
                string line;
                Person tempPerson;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    var personDetails = line.Split(",").ToArray();
                    tempPerson.EmailAddress = personDetails[EMAILADDRESS];
                    tempPerson.Name = personDetails[NAME];
                    People.Add(tempPerson);
                    ++Count;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file can't be read");
                Console.WriteLine(e.Message);
            }
        }

        public int TotalCount() => Count;

        public List<Person> GetPeopleList()
        {
            return People;
        }
    }
}
