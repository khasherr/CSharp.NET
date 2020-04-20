using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Education_System
{
    public partial class Default2 : System.Web.UI.Page
    {
        public static String[] prof_Infor = new String[21];
        public static String[] prof_Name = new String[21];
        public static int count = 1;
        public static int assign = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack){
                RadioButton4.Checked = true;
                RadioButton1.Checked = true;
                Button2.Visible = false;
                Button3.Visible = false;
                Button4.Visible = false;
                TextBox2.Visible = false;
                Label6.Visible = false;
                Button1.Visible = false;
                Label4.Visible = false;
                Label5.Visible = false;
                GridView1.Visible = false;
                Button5.Visible = true;
            }
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            TextBox2.Visible = false;
            Label6.Visible = false;
            GridView1.Visible = false;
            Button5.Visible = false;
            Button1.Visible = true;
            Label4.Visible = true;
            Label5.Visible = true;
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            Button2.Visible = true;
            Button3.Visible = true;
            Button4.Visible = true;
            TextBox2.Visible = true;
            Label6.Visible = true;
            Button1.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            GridView1.Visible = false;
            Button5.Visible = false;
        }

        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            TextBox2.Visible = false;
            Label6.Visible = false;
            Button1.Visible = false;
            Label4.Visible = false;
            Label5.Visible = false;
            GridView1.Visible = true;
            Button5.Visible = true;
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["Prof_AvailabilityConnectionString"].ConnectionString; ;
            using (SqlConnection con = new SqlConnection(constr))
            {
                String query="";
                if (RadioButton4.Checked)
                {
                    query = "SELECT * from PROFESSOR where CourseCode='" + TextBox1.Text+"'";
                }
                else if (RadioButton5.Checked)
                {
                    query = "SELECT * from PROFESSOR where Eductaion='"+"Masters"+ "'AND CourseCode='" + TextBox1.Text + "'";
                }
                else if (RadioButton6.Checked)
                {
                    query = "SELECT * from PROFESSOR where Eductaion='"+"PhD" +"'AND CourseCode='" + TextBox1.Text + "'";
                }
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label4.Text = "Professors with Masters = ";
            Label5.Text = "Professors with PhD = ";
            string constr =   ConfigurationManager.ConnectionStrings["Prof_AvailabilityConnectionString"].ConnectionString; 
                //@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=Prof_Availability; Integrated Security = True";
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                String query = "";
                if (RadioButton4.Checked)
                {

                    query = "SELECT COUNT(*) from PROFESSOR where Eductaion='" + "Masters" + "'AND CourseCode='" + TextBox1.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        Int32 count = (Int32)cmd.ExecuteScalar();
                        Label4.Text = "Professors with Masters = " + count;
                    }
                    query = "SELECT COUNT(*) from PROFESSOR where Eductaion='" + "PhD" + "'AND CourseCode='" + TextBox1.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        Int32 count = (Int32)cmd.ExecuteScalar();
                        Label5.Text = "Professors with PhD = " + count;
                    }
                }
                else if (RadioButton5.Checked)
                {
                    query = "SELECT COUNT(*) from PROFESSOR where Eductaion='" + "Masters" + "'AND CourseCode='" + TextBox1.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        Int32 count = (Int32)cmd.ExecuteScalar();
                        Label4.Text = "Professors with Masters = " + count;
                    }
                }
                else if (RadioButton6.Checked)
                {
                    query = "SELECT COUNT(*) from PROFESSOR where Eductaion='" + "PhD" + "'AND CourseCode='" + TextBox1.Text + "'";
                    using (SqlCommand cmd = new SqlCommand(query))
                    {
                        cmd.Connection = con;
                        Int32 count = (Int32)cmd.ExecuteScalar();
                        Label5.Text = "Professors with PhD = " + count;

                    }
                }
                
            }
        }
        
        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            string constr = ConfigurationManager.ConnectionStrings["Prof_AvailabilityConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                String query = "";
                con.Open();
                if (RadioButton4.Checked)
                {
                    query = "SELECT * from PROFESSOR where CourseCode='" + TextBox1.Text + "'";
                }
                else if (RadioButton5.Checked)
                {
                    query = "SELECT * from PROFESSOR where Eductaion='" + "Masters" + "'AND CourseCode='" + TextBox1.Text + "'";
                }
                else if (RadioButton6.Checked)
                {
                    query = "SELECT * from PROFESSOR where Eductaion='" + "PhD" + "'AND CourseCode='" + TextBox1.Text + "'";
                }
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    SqlDataReader reader = cmd.ExecuteReader();
                    int i = 0;
                    while (reader.Read())
                    {
                        prof_Name[i] = reader[1].ToString();
                        prof_Infor[i] = reader[0].ToString() +" "+ reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString();
                        i++;
                    }
                    TextBox2.Text = prof_Name[0];
                }
            }
        }
        protected void Button3_Click(object sender, EventArgs e)
        {
            TextBox2.Text = prof_Name[count];
            count++;
        }
        String[] prof_Assigned = new String[21];
        protected void Button4_Click(object sender, EventArgs e)
        {
            prof_Assigned[assign] = prof_Infor[count];
            Console.WriteLine(prof_Assigned[assign]);
            assign++;
        }

    }
}