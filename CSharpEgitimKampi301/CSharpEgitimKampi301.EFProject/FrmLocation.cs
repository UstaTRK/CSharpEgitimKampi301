using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }
       
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void btnList_Click(object sender, EventArgs e)
        {
            var values =db.Location.ToList();
            dataGridView1.DataSource = values;

        }

        private void LocationFrm_Load(object sender, EventArgs e)
        {
            var values = db.Guide.Select(x=> new
            {
                FullName = x.GuideName + " " + x.GuideSurname,x.GuideId
            }
            ).ToList();
            cmbGuide.DisplayMember = "FullName";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.LocationCapacity=byte.Parse(nudCapacity.Value.ToString());
            location.City=txtCity.Text;
            location.Country=txtCountry.Text;
            location.LocationPrice=decimal.Parse(txtPrice.Text);
            location.DayNight=txtDayNight.Text;
            location.GuideId=int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("EKLEME BAŞARILI");



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtId.Text);
            var deletevalue = db.Location.Find(id);
            if (deletevalue != null)
            {
                db.Location.Remove(deletevalue);
                db.SaveChanges();
                MessageBox.Show("SİLME BAŞARILI");

            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var updatedvalue = db.Location.Find(id);
            
            updatedvalue.LocationCapacity = byte.Parse(nudCapacity.Value.ToString());
            updatedvalue.City = txtCity.Text;
            updatedvalue.Country = txtCountry.Text;
            updatedvalue.LocationPrice = decimal.Parse(txtPrice.Text);
            updatedvalue.DayNight = txtDayNight.Text;
            updatedvalue.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.Location.AddOrUpdate(updatedvalue);
            db.SaveChanges();
            MessageBox.Show("GÜNCELLEME BAŞARILI");
        }
    }
}
