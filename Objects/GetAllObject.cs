using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker.Objects
{
    public class GetAll
    {
        private List<Band> allBands = new List<Band> {};
        private List<Venue> allVenues = new List<Venue>{};

        public GetAll()
        {
            foreach(var venue in Venue.GetAll())
            {
                allVenues.Add(venue);
            }

            foreach(var band in Band.GetAll())
            {
                allBands.Add(band);
            }
        }

        public List<Band> GetAllBands()
        {
            return allBands;
        }
        public List<Venue> GetAllVenues()
        {
            return allVenues;
        }

    }
}
