using System;
using System.Linq;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEfTravelDbEntities db = new EgitimKampiEfTravelDbEntities();

        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            lblLocationCount.Text = db.Location.Count().ToString();
            lblSumCapacity.Text = 
            lblGuideCount.Text = db.Guide.Count().ToString();
            lblAverageCapacity.Text = (string.Format("{0:F0}", db.Location.Average(x => x.LocationCapacity)));
            lblAverageLocationPrice.Text = (string.Format("{0:F2}", db.Location.Average(x => x.LocationPrice))) + " ₺";
            int lastCountryId= db.Location.Max(x => x.LocationId);
            lblLastCountryName.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();
            lblCappadokiaLocationCapacity.Text = db.Location.Where(x => x.City == "KAPADOKYA").Select(y => y.LocationCapacity).FirstOrDefault().ToString();
            lblTurkiyeAverageCapacity.Text=db.Location.Where(x=> x.Country=="TÜRKİYE").Average(y => y.LocationCapacity).ToString();
            var romeGuideId = db.Location.Where(x => x.City == "ROMA").Select(y => y.GuideId).FirstOrDefault();
            lblRomeTourGuideName.Text=db.Guide.Where(x=> x.GuideId==romeGuideId).Select(y=>y.GuideName+" "+y.GuideSurname).FirstOrDefault().ToString();   
            var maxCapacity=db.Location.Max(x=>x.LocationCapacity);
            lblMaxLocationCapacity.Text=db.Location.Where(x=>x.LocationCapacity==maxCapacity).Select(y=>y.City).FirstOrDefault().ToString();
            var maxTourPrice = db.Location.Max(x => x.LocationPrice);
            lblMaxTourPrice.Text = db.Location.Where(x => x.LocationPrice == maxTourPrice).Select(y => y.City).FirstOrDefault().ToString();
            var guideIdByDeryaCinar=db.Guide.Where(x=>x.GuideName=="DERYA"&& x.GuideSurname=="ÇINAR").Select(y=>y.GuideId).FirstOrDefault();
            lblDeryaCinarTourCount.Text = db.Location.Where(x => x.GuideId == guideIdByDeryaCinar).Count().ToString();

        }
    }
}
