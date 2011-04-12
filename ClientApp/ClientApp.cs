using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Collections;
using System.Text.RegularExpressions;

namespace ClientApp
{
	public class ClientApp : Form
	{
		private GetAJob.WebService.Service service = new GetAJob.WebService.Service();
		public GetAJob.WebService.Service Service { get { return this.service; } }
		
		private DataGridView grid_view;
		private Button get_offers;
		private Button get_people;
		
		private const int per_click = 5;
		private const string HTML_TAG_PATTERN = "<.*?>";
		private int offers_clicks = 1;
		private int people_clicks = 1;
		
		public ClientApp ()
		{
			this.InitializeForm();
		}
		
		private void InitializeForm()
		{			
			this.SetupDataGridView();
			
			this.Text = "GetAJob Client";
			this.Size = new Size(800, 600);
			this.CenterToScreen();
			this.SetupOffers();
			this.SetupPeople();
		}
		
		private void SetupOffers()
		{
			this.get_offers = new Button();
			this.get_offers.Text = "Get Job Offers";
			this.get_offers.Location = new Point(325, 550);
			this.get_offers.Parent = this;
			this.get_offers.Click += new EventHandler(GetOffers);
		}
		
		private void SetupPeople()
		{
			this.get_people = new Button();
			this.get_people.Text = "Get People";
			this.get_people.Location = new Point( 405, 550);
			this.get_people.Parent = this;
			this.get_people.Click += new EventHandler(GetPeople);
		}
		
		private void SetupDataGridView()
		{				
			this.grid_view = new DataGridView();
			this.grid_view.Parent = this;
			this.grid_view.Location = new Point(25, 25);
			this.grid_view.Size = new Size(725, 500);
			this.grid_view.ReadOnly = true;
			this.grid_view.Visible = true;
		}
		
		private void ClearGridView()
		{
			this.grid_view.Columns.Clear();
			this.grid_view.Rows.Clear();
		}
		
		void GetOffers(object sender, EventArgs e)
		{
			var offers = this.Service.getOffers(this.offers_clicks, per_click);
			
			if (this.offers_clicks == 1) {
				this.people_clicks = 1;
				this.ClearGridView();
				this.grid_view.Columns.Add("Company", "Company");
				this.grid_view.Columns.Add("Contact", "Contact");
				this.grid_view.Columns.Add("JobDescription", "Job Description");
				this.grid_view.Columns.Add("JobTitle", "Job Title");
			}
			
			foreach (var offer in offers) {
				var row = new DataGridViewRow();
				string [] values = { offer.Company, offer.Contact, offer.JobTitle, this.StripHTML(offer.JobDescription) };
				row.SetValues(values);
				this.grid_view.Rows.Add(row);
			}
			
			if ( offers.Length > 0 )
				this.offers_clicks++;
		}
		
		private void GetPeople(object sender, EventArgs e)
		{
			var people = this.Service.getPeople(this.people_clicks, per_click);
			
			if (this.people_clicks ==  1) {
				this.offers_clicks = 1;
				this.ClearGridView();
				
				this.grid_view.Columns.Add("FirstName",     "Firstname");
				this.grid_view.Columns.Add("LastName",      "Lastname");
				this.grid_view.Columns.Add("LastEmployer",  "Last Employer");
				this.grid_view.Columns.Add("Content",       "Professional Skills");
			}
			
			foreach (var person in people) {
				var row = new DataGridViewRow();
				string [] values = { person.FirstName, person.LastName, person.Resume.LastEmployer, this.StripHTML(person.Resume.Content) };
				row.SetValues(values);
				this.grid_view.Rows.Add(row);
			}
			
			if (people.Length > 0)
				this.people_clicks++;
		}
		
		private String StripHTML(string html_input)
		{
			return Regex.Replace(html_input, HTML_TAG_PATTERN, string.Empty);
		}
		
		public static void Main()
		{
			Application.Run(new ClientApp());
		}
	}
}

