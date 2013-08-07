using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using MusicCatalog.Models;

namespace MusicCatalog.Controllers
{
    public class SongsController : ApiController
    {
        private MusicShopEntities db = new MusicShopEntities();

        // GET api/Songs
        public IEnumerable<Song> GetSongs()
        {
            var songs = db.Songs.Include(s => s.Artist).Include(s => s.Genre);
            return songs.AsEnumerable();
        }

        // GET api/Songs/5
        public Song GetSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return song;
        }

        // PUT api/Songs/5
        public HttpResponseMessage PutSong(int id, Song song)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != song.id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(song).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Songs
        public HttpResponseMessage PostSong(Song song)
        {
            if (ModelState.IsValid)
            {
                db.Songs.Add(song);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, song);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = song.id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Songs/5
        public HttpResponseMessage DeleteSong(int id)
        {
            Song song = db.Songs.Find(id);
            if (song == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Songs.Remove(song);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, song);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}