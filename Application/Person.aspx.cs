using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Application
{
    public partial class Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetLabels();
        }

        protected void SetLabels(Int32 rowId = 1)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
            var dt = new DataTable();
            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmdd = new SqlCommand("SELECT Person.ID, Name, DOB, Age, Hobbies.Hobby FROM Person, Hobbies where dbo.Person.Hobby = dbo.Hobbies.ID and Person.ID=" + rowId.ToString(), conn))
                {
                    using (var adapter = new SqlDataAdapter(cmdd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            if (dt.Rows.Count > 0)
            {
                lblID.Text = dt.Rows[0]["ID"].ToString().Trim();
                lblAge.Text = dt.Rows[0]["Age"].ToString().Trim();
                lblName.Text = dt.Rows[0]["Name"].ToString().Trim();
                lblDob.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString().Trim()).ToShortDateString();
                lblHobby.Text = dt.Rows[0]["Hobby"].ToString().Trim();
            }
        }

        protected void lnkPrev_OnClick(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                int rowId;
                var parseId = Int32.TryParse(lblID.Text, out rowId);
                if (parseId && rowId > 1)
                {
                    rowId -= 1;
                }
                else
                {
                    rowId = 2000;
                }

                SetLabels(rowId);
            }
        }

        protected void lnkNext_OnClick(object sender, EventArgs e)
        {
            int rowId;
            var parseId = Int32.TryParse(lblID.Text, out rowId);
            if (parseId && rowId < 2000)
            {
                rowId += 1;
            }
            else
            {
                rowId = 1;
            }
            SetLabels(rowId);
        }
    }
}