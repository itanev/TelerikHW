using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoviesCrud.Models;
using MoviesCrud.ViewModels;

namespace MoviesCrud.Controllers
{
    public class MoviesController : Controller
    {
        //
        // GET: /Movies/
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Movies/All
        [HttpGet]
        public JsonResult All()
        {
            var context = new MovieEntities();
            var movies = context.Movies.ToList();

            var movieModels = new List<Movie>();

            foreach (var movie in movies)
            {
                movieModels.Add(this.GenerateMovieModel(movie));
            }

            return Json(movieModels, JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Movies/Details/5
        public ActionResult Details(int id)
        {
            var context = new MovieEntities();
            var movie = context.Movies.Find(id);

            if (movie == null)
            {
                return View("NotFound");
            }

            var movieModel = this.GenerateMovieModel(movie);

            return View(movieModel);
        }
        
        //
        // GET: /Movies/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movies/Create
        [HttpPost]
        public ActionResult Create(Movie currMovie)
        {
            try
            {
                var context = new MovieEntities();

                using (context)
                {
                    var director = GetPeople(currMovie, context, Kind.Director);
                    var maleActor = GetPeople(currMovie, context, Kind.MaleActor);
                    var femaleActor = GetPeople(currMovie, context, Kind.FemaleActor);

                    var movieToAdd = new Movies()
                    {
                        title = currMovie.Title,
                        year = currMovie.Year,
                        directorId = director.id,
                        leadingMaleRoleId = maleActor.id,
                        leadingFemaleRoleId = femaleActor.id
                    };

                    context.Movies.Add(movieToAdd);
                    context.SaveChanges();
                }

                return View();
            }
            catch
            {
                return View("Error");
            }
        }

        //
        // GET: /Movies/Edit/5
        public ActionResult Edit(int id)
        {
            var context = new MovieEntities();
            var movie = context.Movies.FirstOrDefault(m => m.id == id);

            if (movie == null)
            {
                return View("NotFound");
            }

            var movieToEditModel = this.GenerateMovieModel(movie);
            return View(movieToEditModel);
        }

        //
        // POST: /Movies/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Movie currMovie)
        {
            try
            {
                var context = new MovieEntities();
                using (context)
                {
                    var movieToUpdate = context.Movies.Find(id);

                    if (movieToUpdate != null)
                    {
                        var director = GetPeople(currMovie, context, Kind.Director);
                        var maleActor = GetPeople(currMovie, context, Kind.MaleActor);
                        var femaleActor = GetPeople(currMovie, context, Kind.FemaleActor);

                        movieToUpdate.title = currMovie.Title;
                        movieToUpdate.year = currMovie.Year;
                        movieToUpdate.leadingMaleRoleId = maleActor.id;
                        movieToUpdate.leadingFemaleRoleId = femaleActor.id;
                        movieToUpdate.directorId = director.id;

                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Error");
            }
        }

        //
        // GET: /Movies/Delete/5
        public ActionResult Delete(int id)
        {
            var context = new MovieEntities();
            var movieToRemove = context.Movies.Find(id);
            var movieViewModel = GenerateMovieModel(movieToRemove);

            return View(movieViewModel);
        }

        //
        // POST: /Movies/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Movie movie)
        {
            try
            {
                var context = new MovieEntities();
                using (context)
                {
                    var movieToRemove = context.Movies.Find(id);
                    if (movieToRemove != null)
                    {
                        context.Movies.Remove(movieToRemove);
                        context.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        #region private methods
        private ViewModels.People GetCurrPeople(Movie currMovie, Kind kind)
        {
            ViewModels.People currPeople = new ViewModels.People();

            switch (kind)
            {
                case Kind.Director:
                    currPeople = currMovie.Director;
                    break;
                case Kind.MaleActor:
                    currPeople = currMovie.LeadingMale;
                    break;
                default:
                    currPeople = currMovie.LeadingFemale;
                    break;
            }

            return currPeople;
        }
        private Models.People GetPeople(Movie currMovie, MovieEntities context, Kind kind)
        {
            ViewModels.People currPeople = GetCurrPeople(currMovie, kind);

            var kindName = Enum.GetName(typeof(Kind), kind);

            var people = context.People.Include("Kinds")
                            .FirstOrDefault(x => x.Kinds.name == kindName &&
                                            x.firstName == currPeople.FirstName &&
                                            x.lastName == currPeople.LastName);

            if (people == null)
            {
                people = this.AddPeople(currMovie, context, people, Kind.Director);
            }

            return people;
        }

        private Models.People AddPeople(Movie currMovie, MovieEntities context, Models.People people, Kind kind)
        {
            ViewModels.People currPeople = GetCurrPeople(currMovie, kind);

            var currStudio = context.Studio.FirstOrDefault(x => x.name == currPeople.Studio.Name);

            if (currStudio == null)
            {
                currStudio = AddStudio(currPeople.Studio, context);
            }

            people = new Models.People()
            {
                firstName = currMovie.Director.FirstName,
                lastName = currMovie.Director.LastName,
                age = currMovie.Director.Age,
                studioId = currStudio.id,
                kindId = (int)kind
            };

            context.People.Add(people);
            context.SaveChanges();

            return people;
        }

        private Models.Studio AddStudio(ViewModels.Studio studio, MovieEntities context)
        {
            var newStudio = new Models.Studio()
            {
                name = studio.Name,
                address = studio.Address
            };

            context.Studio.Add(newStudio);
            context.SaveChanges();
            return newStudio;
        }
        private Movie GenerateMovieModel(Movies movie)
        {
            var movieModel = new Movie()
            {
                Id = movie.id,
                Title = movie.title,
                Year = movie.year,
                Director = new MoviesCrud.ViewModels.People()
                {
                    FirstName = movie.Director.firstName,
                    LastName = movie.Director.lastName,
                    Age = movie.Director.age,
                    Studio = new MoviesCrud.ViewModels.Studio()
                    {
                        Address = movie.Director.Studio.address,
                        Name = movie.Director.Studio.name
                    }
                },
                LeadingFemale = new MoviesCrud.ViewModels.People()
                {
                    FirstName = movie.LeadingFemale.firstName,
                    LastName = movie.LeadingFemale.lastName,
                    Age = movie.LeadingFemale.age,
                    Studio = new MoviesCrud.ViewModels.Studio()
                    {
                        Address = movie.LeadingFemale.Studio.address,
                        Name = movie.LeadingFemale.Studio.name
                    }
                },
                LeadingMale = new MoviesCrud.ViewModels.People()
                {
                    FirstName = movie.LeadingMale.firstName,
                    LastName = movie.LeadingMale.lastName,
                    Age = movie.LeadingMale.age,
                    Studio = new MoviesCrud.ViewModels.Studio()
                    {
                        Address = movie.LeadingMale.Studio.address,
                        Name = movie.LeadingMale.Studio.name
                    }
                }
            };

            return movieModel;
        }
    }
}

#endregion
