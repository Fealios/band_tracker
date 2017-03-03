
using Nancy;
using System.Collections.Generic;
using BandTracker.Objects;

namespace BandTracker
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] =_=> {
                return View["venues.cshtml", Venue.GetAll()];
            };

            Post["/"] =_=> {
                Venue tempVenue = new Venue(Request.Form["venue-name"]);
                tempVenue.Save();
                return View["venues.cshtml", Venue.GetAll()];
            };

            Get["/single-venue/{id}"] =parameter=> {
                Venue tempVenue = Venue.Find(parameter.id);
                return View["single-venue.cshtml", tempVenue];
            };

            Get["/add-band"] =_=> {
                return View["add-band.cshtml", Venue.GetAll()];
            };

            Post["/add-band"] =_=> {
                Band newBand = new Band(Request.Form["band-name"]);
                newBand.Save();
                Venue tempVenue = Venue.Find(Request.Form["venue-select"]);
                tempVenue.AddBand(newBand);
                return View["success.cshtml", "add-band"];
            };

            Get["/band-list"] =_=> {
                return View["band-list", Band.GetAll()];
            };

            Get["/single-band/{id}"] =parameter=> {
                Band tempBand = Band.Find(parameter.id);

                return View["single-band.cshtml", tempBand];
            };

        }
    }
}
