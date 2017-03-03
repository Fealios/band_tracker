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

            Assert.Equal(allBands, Band.GetAll());
        }

        public void Dispose()
        {
            Band.DeleteAll();
        }
    }
}
