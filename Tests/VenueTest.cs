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
            List<Venue> allVenues = new List<Venue>{testVenue};
            testVenue.Save();

            testVenue.GetName();
            Venue.GetAll()[0].GetName();

            Assert.Equal(allVenues, Venue.GetAll());
        }

        public void Dispose()
        {
            Venue.DeleteAll();
        }
    }
}
