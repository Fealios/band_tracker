using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker.Objects
{
    public class Band
    {
        private int _id;
        private string _name;

        public Band(string name, int id = 0)
        {
            _id = id;
            _name = name;
        }

        public override bool Equals(System.Object otherBand)
        {
            if (!(otherBand is Band))
            {
                return false;
            }
            else
            {
                Band newBand = (Band) otherBand;
                bool idEquality = this.GetId() == newBand.GetId();
                bool nameEquality = this.GetName() == newBand.GetName();

                return (idEquality && nameEquality);
            }
        }

        public void Save()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands(name) OUTPUT INSERTED.id VALUES(@BandName);", conn);
            SqlParameter nameParameter = new SqlParameter("@BandName", this.GetName());
            cmd.Parameters.Add(nameParameter);

            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                this._id = rdr.GetInt32(0);
            }
            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }
        }

        public static List<Band> GetAll()
        {
            List<Band> allBands = new List<Band>{};

            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
            SqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);

                Band newBand = new Band(name, id);
                allBands.Add(newBand);
            }

            if (rdr != null)
            {
                rdr.Close();
            }
            if (conn != null)
            {
                conn.Close();
            }

            return allBands;
        }

        public void AddVenue(Venue newVenue)
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO bands_venues(band_id, venue_id) VALUES(@BandId, @VenueId);", conn);

            SqlParameter bandId = new SqlParameter("@BandId", this.GetId());
            SqlParameter venueId = new SqlParameter("@VenueId", newVenue.GetId());

            cmd.Parameters.Add(bandId);
            cmd.Parameters.Add(venueId);

            cmd.ExecuteNonQuery();

            if(conn != null)
            {
                conn.Close();
            }
        }

        public List<Venue> GetVenues()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT venues.* FROM bands JOIN bands_venues ON (bands_venues.band_id = bands.id) JOIN venues ON (bands_venues.venue_id = venues.id) WHERE bands.id = @BandId;", conn);
            // SqlCommand cmd = new SqlCommand("SELECT bands.* FROM venues JOIN bands_venues ON (bands_venues.venue_id = venues.id) JOIN bands ON (bands_venues.band_id = bands.id) WHERE venues.id = @VenueId;", conn);


            SqlParameter bandId = new SqlParameter("@BandId", this.GetId());

            cmd.Parameters.Add(bandId);

            SqlDataReader rdr = cmd.ExecuteReader();
            List<Venue> venuesPlayed = new List<Venue>{};

            while(rdr.Read())
            {
                int venueId = rdr.GetInt32(0);
                string venueName = rdr.GetString(1);

                Venue newVenue = new Venue(venueName, venueId);
                venuesPlayed.Add(newVenue);
            }

            if(rdr != null)
            {
                rdr.Close();
            }
            if(conn != null)
            {
                conn.Close();
            }

            return venuesPlayed;
        }

        public static void DeleteAll()
        {
            SqlConnection conn = DB.Connection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public string GetName()
        {
            return _name;
        }

        public int GetId()
        {
            return _id;
        }
    }
}
