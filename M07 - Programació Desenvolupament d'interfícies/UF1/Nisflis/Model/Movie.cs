using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Model
{
     public class Movie
    {


        private string title;
        private int rating;
		private string poster;
        private decimal price;
        private string description;
        private string coverimge;


        public Movie(string title, int rating, string poster, decimal price, string description, string coverimge)
        {
			
            this.title = title;
            this.rating = rating;
            this.poster = poster;
            this.price = price;
            this.description = description;
            this.coverimge = coverimge;
        }


        public string Coverimg
		{
			get { return coverimge; }
			set { coverimge = value; }
		}


		public String Description
		{
			get { return description; }
			set { description = value; }
		}


		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}


		public string Poster
		{
			get { return poster; }
			set { poster = value; }
		}



		public int Rating
		{
			get { return rating; }
			set { rating = value; }
		}



		public string Title
		{
			get { return title; }
			set { title = value; }
		}



	}
}
