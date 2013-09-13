using _01.Continents.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.Continents
{
    public partial class Continents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void InsertTown(object sender, ListViewInsertEventArgs e)
        {
            var townName = (e.Item.FindControl("TownName") as TextBox).Text;
            var townCountryName = (e.Item.FindControl("TownCountryName") as TextBox).Text;
            var townPopulation = int.Parse((e.Item.FindControl("TownPopulation") as TextBox).Text);

            ContinentsEntities db = new ContinentsEntities();
            using (db)
            {
                var country = db.Countries.FirstOrDefault(c => c.name == townCountryName);

                if (country != null)
                {
                    db.Towns.Add(new Towns()
                    {
                        name = townName,
                        population = townPopulation,
                        countryId = country.id
                    });

                    db.SaveChanges();   
                }
            }
        }

        protected void InsertCountry(object sender, EventArgs e)
        {
            Control control = DataGridCountries.FooterRow;

            if (control == null)
            {
                control = DataGridCountries.Controls[0].Controls[0];
            }

            var countryName = (control.FindControl("CountryName") as TextBox).Text;
            var countryContinentName = (control.FindControl("CountryContinentName") as TextBox).Text;
            var countryLanguage = (control.FindControl("CountryLanguage") as TextBox).Text;
            var countryPopulation = int.Parse((control.FindControl("CountryPopulation") as TextBox).Text);

            ContinentsEntities db = new ContinentsEntities();
            using (db)
            {
                var continent = db.Continents.FirstOrDefault(c => c.name == countryContinentName);
                var contId = 0;

                if (continent == null)
                {
                    db.Continents.Add(new Models.Continents()
                    {
                        name = countryContinentName
                    });

                    contId = db.Continents.Count();
                }
                else
                {
                    contId = continent.id;
                }

                db.Countries.Add(new Countries()
                {
                    name = countryName,
                    language = countryLanguage,
                    population = countryPopulation,
                    continentId = contId
                });

                db.SaveChanges();
            }
        }
    }
}