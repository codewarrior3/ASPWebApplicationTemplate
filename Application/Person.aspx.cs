using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace Application
{
    public partial class Person : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtPerson = new DataTable();
                SetLabels(ref dtPerson);
            }
        }

        protected DataTable GetPetsonByID(Int32 rowId)
        {
            DataTable dt = new DataTable();
            var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd =
                    new SqlCommand(
                        "SELECT Person.ID, Name, DOB, Age, Hobbies.Hobby FROM Person, Hobbies where dbo.Person.Hobby = dbo.Hobbies.ID and Person.ID=" +
                        rowId.ToString(), conn))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        //0 for none
        //1 for add
        //2 for subtract
        protected void SetLabels(ref DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                lblID.Text = dt.Rows[0]["ID"].ToString().Trim();
                lblAge.Text = dt.Rows[0]["Age"].ToString().Trim();
                lblName.Text = dt.Rows[0]["Name"].ToString().Trim();
                lblDob.Text = Convert.ToDateTime(dt.Rows[0]["DOB"].ToString().Trim()).ToShortDateString();
                lblHobby.Text = dt.Rows[0]["Hobby"].ToString().Trim();
            }
        }

        protected void Previous()
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
                lblID.Text = rowId.ToString();
                GetPetsonByID(rowId);
                DataTable dtPerson = GetPetsonByID(rowId);
                SetLabels(ref dtPerson);
            }
        }

        protected void Next()
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

            lblID.Text = rowId.ToString();
            DataTable dtPerson = GetPetsonByID(rowId);
            SetLabels(ref dtPerson);
        }

        protected void lnkPrev_OnClick(object sender, EventArgs e)
        {
            Previous();
        }

        protected void lnkNext_OnClick(object sender, EventArgs e)
        {
            Next();
        }
    }
}