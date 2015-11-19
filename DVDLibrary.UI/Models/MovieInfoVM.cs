using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DVDLibrary.Models;

namespace DVDLibrary.UI.Models
{
    public class MovieInfoVM
    {
        //Added this class for the dropDownList in the add view

        public List<SelectListItem> MpaaRatingsList { get; set; }
        public List<SelectListItem> ActorsList { get; set; }
        public List<SelectListItem> BorrowersList { get; set; }
        public List<SelectListItem> DirectorsList { get; set; }
        public List<SelectListItem> StudiosList { get; set; } 

        public MovieInfo Movie { get; set; }

        public MovieInfoVM()
        {
            MpaaRatingsList = new List<SelectListItem>();
            ActorsList = new List<SelectListItem>();
            BorrowersList = new List<SelectListItem>();
            DirectorsList = new List<SelectListItem>();
            StudiosList = new List<SelectListItem>();
            Movie = new MovieInfo();
        }

        public void CreateMpaaRatingsList(List<MpaaRating> listOfMpaaRatings)
        {
            foreach (var m in listOfMpaaRatings)
            {
                var newItem = new SelectListItem();
                newItem.Text = m.FilmRating;
                newItem.Value = m.MpaaRatingID.ToString();

                MpaaRatingsList.Add(newItem);
            }
        }

        public void CreateActorsList(List<Actor> listOfActors)
        {
            foreach (var a in listOfActors)
            {
                var newItem = new SelectListItem();
                newItem.Text = string.Concat(a.FirstName, " ", a.LastName);
                newItem.Value = a.ActorID.ToString();

                ActorsList.Add(newItem);
            }
        }

        public void CreateBorrowersList(List<Borrower> listOfBorrowers)
        {
            foreach (var b in listOfBorrowers)
            {
                var newItem = new SelectListItem();
                newItem.Text = string.Concat(b.FirstName, " ", b.LastName);
                newItem.Value = b.BorrowerID.ToString();

                BorrowersList.Add(newItem);
            }
        }

        public void CreateDirectorsList(List<Director> listofDirectors)
        {
            foreach (var d in listofDirectors)
            {
                var newItem = new SelectListItem();
                newItem.Text = string.Concat(d.FirstName, " ", d.LastName);
                newItem.Value = d.DirectorID.ToString();

                DirectorsList.Add(newItem);
            }
        }

        public void CreateStudiosList(List<Studio> listOfStudios)
        {
            foreach (var s in listOfStudios)
            {
                var newItem = new SelectListItem();
                newItem.Text = s.StudioName;
                newItem.Value = s.StudioID.ToString();

                StudiosList.Add(newItem);
            }
        }

    }
}