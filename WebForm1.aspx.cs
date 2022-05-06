using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PKRtravels
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //string cs = "data source =.; database =BooKMyBUS; integrated security=SSPI ";
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=BooKMyBUS;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into BusInfo values ('" + DropDownList1 + "','" + TextBox1 + "','" + TextBox2 + "','" + TextBox3 + "')";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand conn =new SqlCommand("select * from BusInfo");
            SqlDataAdapter da = new SqlDataAdapter(conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DropDownList1.DataTextField = ds.Tables[0].Columns["BoardingPoint"].ToString();
            DropDownList1.DataValueField = ds.Tables[0].Columns["BusID"].ToString();
            DropDownList1.DataSource = ds.Tables[0];
            DropDownList1.DataBind();

        }
    }
}