using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;
using BandTracker.Objects;

namespace BandTracker
{
    public class VenueTest : IDisposable
    {
        public VenueTest()
        {
            DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
        }

        [Fact]
        public void TEST_Save_SaveVenueToDB()
        {
            Venue testVenue = new Venue("El Corozon");
            testVenue.Save();
            List<Venue> allVenues = new List<Venue>{testVenue};
            Venue.GetAll()[0].GetName();

            Assert.Equal(allVenues, Venue.GetAll());
        }

        [Fact]
        public void TEST_AddBandToVenueRelationship()
        {
            Venue testVenue = new Venue("El Corozon");
            testVenue.Save();
            Band testBand = new Band("Mayday Parade");
            testBand.Save();

            testVenue.AddBand(testBand);
            List<Band> bandsAtVenue = new List<Band> {testBand};

            Assert.Equal(bandsAtVenue, testVenue.GetBands());
        }

        public void Dispose()
        {
            Venue.DeleteAll();
        }
    }
}
