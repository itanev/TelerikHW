using _01.CarSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01.CarSearch
{
    public partial class Search : System.Web.UI.Page
    {
        private List<Producer> CarProducers { get; set; }
        private static List<Model> CarModels { get; set; }
        private List<Producer> FillDataSource()
        {
            var bmwModels = new List<Model>()
            {
                new Model() 
                {
                    Name = "550", 
                    Extras = new List<Extra>() 
                    { 
                        new Extra() { Name="bmw 550 extra 1"},
                        new Extra() { Name="bmw 550 extra 2"},
                        new Extra() { Name="bmw 550 extra 3"},
                    }
                },
                new Model() 
                {
                    Name = "330", 
                    Extras = new List<Extra>() 
                    { 
                        new Extra() { Name="bmw 330 extra 1"},
                        new Extra() { Name="bmw 330 extra 2"},
                        new Extra() { Name="bmw 330 extra 3"},
                    }
                },
                new Model() 
                {
                    Name = "840", 
                    Extras = new List<Extra>() 
                    { 
                        new Extra() { Name="bmw 840 extra 1"},
                        new Extra() { Name="bmw 840 extra 2"},
                        new Extra() { Name="bmw 840 extra 3"},
                    }
                }
            };

            var vwModels = new List<Model>()
            {
                new Model() 
                {
                    Name = "1200", 
                    Extras = new List<Extra>() 
                    { 
                        new Extra() { Name="vw 1200 extra 1"},
                        new Extra() { Name="vw 1200 extra 2"},
                        new Extra() { Name="vw 1200 extra 3"},
                    }
                },
                new Model() 
                {
                    Name = "1300", 
                    Extras = new List<Extra>() 
                    { 
                        new Extra() { Name="vw 1300 extra 1"},
                        new Extra() { Name="vw 1300 extra 2"},
                        new Extra() { Name="vw 1300 extra 3"},
                    }
                },
                new Model() 
                {
                    Name = "1500", 
                    Extras = new List<Extra>() 
                    { 
                        new Extra() { Name="vw 1500 extra 1"},
                        new Extra() { Name="vw 1500 extra 2"},
                        new Extra() { Name="vw 1500 extra 3"},
                    }
                }
            };

            var producers = new List<Producer>()
            {
                new Producer() { Name = "BMW", Models = bmwModels },
                new Producer() { Name = "VW", Models = vwModels },
            };

            return producers;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.info.Text = "";
            this.CarProducers = FillDataSource();

            if (!this.Page.IsPostBack)
            {
                this.Models.Visible = false;
                this.Extras.Visible = false;
                var producersDataSource = from p in this.CarProducers
                                          select p.Name;

                this.Producers.DataSource = producersDataSource;
                this.DataBind();
            }
        }

        protected void OnProducerChange(object sender, EventArgs e)
        {
            this.Models.Visible = true;
            this.Extras.Visible = false;
            var producerName = this.Producers.SelectedValue;
            var currProducer = this.CarProducers.FirstOrDefault(p => p.Name == producerName);

            if (currProducer != null)
            {
                CarModels = currProducer.Models.ToList();
                var modelsDataSource = (from m in CarModels
                                       select m.Name).ToList();

                this.Models.DataSource = modelsDataSource;
                this.DataBind();
            }
        }

        protected void OnModelChange(object sender, EventArgs e)
        {
            this.Extras.Visible = true;
            this.Models.Visible = true;
            var modelName = this.Models.SelectedValue;
            var currModel = CarModels.FirstOrDefault(m => m.Name == modelName);

            if (currModel != null)
            {
                var extrasDataSource = (from ex in currModel.Extras
                                        select ex.Name).ToList();

                this.Extras.DataSource = extrasDataSource;
                this.DataBind();
            }
        }

        protected void OnSubmit(object sender, EventArgs e)
        {
            var producer = "Producer: " + this.Producers.SelectedValue;
            var model = "Model: " + this.Models.SelectedValue;
            StringBuilder extras = new StringBuilder();
            extras.Append("Extras: ");

            foreach (ListItem extra in this.Extras.Items)
            {
                if (extra.Selected)
                {
                    extras.AppendFormat("{0}, ", extra.Value);
                }
            }

            var resultText = string.Format("<br />{0}<br />{1}<br />{2}<br />", producer, model, extras);
            this.info.Text = resultText;
        }
    }
}