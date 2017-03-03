using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using BandTracker.Objects;

namespace BandTracker
{
    public class BandTest : IDisposable
    {
        public BandTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void TEST_Save_SaveVenueToDB()
        {
            Band testBand = new Band("Mayday Parade");
            List<Band> allBands = new List<Band>{testBand};
            testBand.Save();

            testBand.GetName();
            Band.GetAll()[0].GetName();

            foreach(var band in Band.GetAll())
            {
                Console.WriteLine(band.GetName());
                Console.WriteLine("hi");
            }

            Assert.Equal(allBands, Band.GetAll());
        }

        [Fact]
        public void TEST_AddVenueToBandRelationship()
        {
            Band testBand = new Band("Maday Parade");
            testBand.Save();

            Venue testVenue = new Venue("WAMU Theatre");
            testVenue.Save();

            testBand.AddVenue(testVenue);

            List<Venue> venuesPlayed = new List<Venue>{testVenue};

            Assert.Equal(venuesPlayed, testBand.GetVenues());
        }

        public void Dispose()
        {
            Band.DeleteAll();
            Venue.DeleteAll();
            Venue.DeleteRelationship();
        }
    }
}
