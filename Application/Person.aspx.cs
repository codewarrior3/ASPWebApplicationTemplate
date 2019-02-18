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
            {
                DataTable dtPerson;
                dtPerson = GetPetsonById(1);
                SetLabels(ref dtPerson);
            }
        }

        protected DataTable GetPetsonById(Int32 rowId)
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

        protected void Previous(ref DataTable dtPerson, Int32 maxID)
        {
            if (!String.IsNullOrEmpty(lblID.Text))
            {
                var parseId = Int32.TryParse(lblID.Text, out var rowId);
                if (parseId && rowId > 1)
                {
                    rowId -= 1;
                }
                else
                {
                    rowId = maxID;
                }
                lblID.Text = rowId.ToString();
                GetPetsonById(rowId);
                dtPerson = GetPetsonById(rowId);
                SetLabels(ref dtPerson);
            }
        }

        protected void Next(ref DataTable dtPerson, Int32 maxID)
        {
            var parseId = Int32.TryParse(lblID.Text, out var rowId);
            if (parseId && rowId < maxID)
            {
                rowId += 1;
            }
            else
            {
                rowId = 1;
            }

            lblID.Text = rowId.ToString();
            dtPerson = GetPetsonById(rowId);
            SetLabels(ref dtPerson);
        }

        protected void lnkPrev_OnClick(object sender, EventArgs e)
        {
            DataTable dtPerson = new DataTable();
            Int32 maxID = GetMaxIDFromTable();
            while (dtPerson.Rows.Count == 0)
            {
                Previous(ref dtPerson, maxID);
            }
        }

        //Loop until the next valid ID is found if max, then start back at 1
        protected void lnkNext_OnClick(object sender, EventArgs e)
        {
            DataTable dtPerson = new DataTable();
            Int32 maxID = GetMaxIDFromTable();
            while (dtPerson.Rows.Count == 0)
            {
                Next(ref dtPerson, maxID);
            }
        }

        //Gets the Max ID from Person to see how high to loop.
        protected Int32 GetMaxIDFromTable()
        {
            Int32 maxId = 1;

            DataTable dt = new DataTable();
            var connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;

            using (var conn = new SqlConnection(connectionString))
            {
                using (var cmd =
                    new SqlCommand(
                        "SELECT MAX(ID) as ID FROM Person", conn))
                {
                    using (var adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            if (dt.Rows.Count > 0 && dt.Columns.Contains("ID"))
            {
                bool parseSuccess = Int32.TryParse(dt.Rows[0]["ID"].ToString().Trim(), out maxId);
            }

            return maxId;
        }
    }
}