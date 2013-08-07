using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MusicCatalog.Models;

namespace MusicCatalog.Controllers
{
    public class AlbumsController : ApiController
    {
        private static MusicShopEntities musicShop;

        public AlbumsController()
        {
            musicShop = new MusicShopEntities();
            musicShop.Configuration.ProxyCreationEnabled = false;
        }

        // GET api/albums
        public IEnumerable<Album> Get()
        {
            return musicShop.Albums.ToList();
        }

        // GET api/albums/5
        public Album Get(int id)
        {
            var resultAlbum = (from a in musicShop.Albums
                               where a.id == id
                               select a).FirstOrDefault();

            if (resultAlbum == null)
            {
                throw new ArgumentOutOfRangeException("Album with the specified ID does not exist!");
            }

            return resultAlbum;
        }

        // POST api/albums
        public HttpResponseMessage Post([FromBody]Album album)
        {
            musicShop.Albums.Add(album);
            musicShop.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Album added successful.");
        }

        // PUT api/albums/5
        public HttpResponseMessage Put(int id, [FromBody]Album album)
        {
            var albumAtId = (from a in musicShop.Albums
                             where a.id == id
                             select a).FirstOrDefault();

            if (albumAtId == null)
            {
                throw new ArgumentOutOfRangeException("Album with the specified ID does not exist!");
            }

            albumAtId.Artists = album.Artists;
            albumAtId.producer = album.producer;
            albumAtId.Songs = album.Songs;
            albumAtId.title = album.title;
            albumAtId.year = album.year;

            musicShop.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Album has been updated!");
        }

        // DELETE api/albums/5
        public HttpResponseMessage Delete(int id)
        {
            var currAlbum = (from a in musicShop.Albums
                             where a.id == id
                             select a).FirstOrDefault();

            if (currAlbum == null)
            {
                return this.Request.CreateResponse(HttpStatusCode.NotFound, "Album not found!");
            }

            currAlbum.Songs.Clear();
            currAlbum.Artists.Clear();

            musicShop.Albums.Remove(currAlbum);
            musicShop.SaveChanges();

            return this.Request.CreateResponse(HttpStatusCode.OK, "Album has been deleted.");
        }
    }
}