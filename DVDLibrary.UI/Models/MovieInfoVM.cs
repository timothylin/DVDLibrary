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

        public List<SelectListItem> ListMpaa { get; set; }

        public int MovieID { get; set; }
        public string Title { get; set; }
        public MpaaRating MpaaRating { get; set; }
        public Director Director { get; set; }
        public int ReleaseDate { get; set; }
        public Studio Studio { get; set; }
        public List<Actor> Actors { get; set; }

        public MovieInfoVM()
        {
            Actors = new List<Actor>();
            MpaaRating = new MpaaRating();
            Director = new Director();
            Studio = new Studio();
            ListMpaa = new List<SelectListItem>();
        }

        public void CreateMpaaList(List<MpaaRating> listmpaa)
        {
            foreach (var m in listmpaa)
            {
                var newItem = new SelectListItem();
                newItem.Text = m.FilmRating;
                newItem.Value = m.MpaaRatingID.ToString();

                ListMpaa.Add(newItem);
            }
        }
    }
}