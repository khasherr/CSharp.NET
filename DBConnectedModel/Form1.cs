using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DBConnectedModel
{
    public partial class Form1 : Form
    {
        private SqlConnection conn = new SqlConnection();
        private String conString = @"Server=DESKTOP-KD5D2CF\KHANSQL; Database=NetClass1; User=Mike; Password=mike1234";
        private SqlCommand cmd;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)


        {

            cmbAirlineType.SelectedIndex = 0;
            refreshData();
        }

        private void refreshData()
        {
            //instantiate sql connection object
            // SqlConnection conn = new SqlConnection();
            //connection string - user must have permission to access the db
            //conn.ConnectionString = @"Server=DESKTOP-KD5D2CF\KHANSQL; Database=NetClass1; User=Mike; Password=mike1234";

            conn.ConnectionString = conString;
            SqlCommand cmd = conn.CreateCommand();


            //instantiate command object
            cmd = conn.CreateCommand();

            try
            {
                String query = "Select * From dbo.FlightInfo";
                cmd.CommandText = query;
                conn.Open();

                //select statement executed
                SqlDataReader reader = cmd.ExecuteReader();

                //display it datagird view 
                DataTable dt = new DataTable();
                dt.Load(reader);

                dataGridView1.DataSource = dt;

                //configure the combox- name of combox is cmbSelect
                cmbSelect.DisplayMember = "Airline";
                cmbSelect.ValueMember = "ID";
                cmbSelect.DataSource = dt;
                reader.Close();
            }

            catch (Exception ex)
            {
                String msg = ex.Message.ToString();
                String caption = "error";

                MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                //cleans up all the memory in the ram
                cmd.Dispose();
                conn.Close();
            }


        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            string airline = tbAirline.Text;
            string flight = tbFlightNum.Text;
            string destination = tbDestination.Text;
            string airplane = cmbAirlineType.SelectedItem.ToString();

            if ((airline == " ") || (flight == " ") || (destination == " ") || (airplane == " "))
            {
                string msg = "No textbox can be empty ";
                string caption = "Error !";
                MessageBox.Show(caption, msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();
            }

            try
            {
                string query = "Insert into FlightInfo values ('"
                    + airline + "' ,'"
                    + flight + "','"
                    + destination + "','"
                    + airplane + "');";

                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteScalar();
                MessageBox.Show("New flight is added sucessfully", "Success!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            catch (Exception ex)
            {
                String msg = ex.Message.ToString();
                String caption = "Error!";
                MessageBox.Show(caption, msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                cmd.Dispose();
                conn.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int flID = Convert.ToInt32(cmbSelect.SelectedValue);

            //retrieve flight name airline
            String airline = tbAirline.Text;
            String flight = tbFlightNum.Text;
            String destination = tbDestination.Text;
            String airplane = cmbAirlineType.SelectedItem.ToString();

            if ((airline == " ") || (flight == " ") || (destination == " ") || (airplane == " "))
            {
                string msg = "No textbox can be empty ";
                string caption = "Error !";
                MessageBox.Show(caption, msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
            {
                //update flight info  set airline = '???', flightNum = '???', destination = '???', 
                // airlineType = '???' where id = ???

                String query = "Update  Flightinfo set Airline ='" + airline + "', FlightNum='" + flight + "', Destination='" + destination +
                    "', AirplaneType='" + airplane + "'where ID=" + flID;

                conn.ConnectionString = conString;
                cmd = conn.CreateCommand();

                try
                {

                    cmd.CommandText = query;
                    conn.Open();
                    cmd.ExecuteScalar();
                }

                catch (Exception ex)
                {
                    String msg = ex.Message.ToString();
                    String caption = "Error!";
                    MessageBox.Show(caption, msg, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //delete from flightinfo where ID = ?? 
            int flID = Convert.ToInt32(cmbSelect.SelectedValue);
            conn.ConnectionString = conString;
            cmd = conn.CreateCommand();

            try
            {

                String query = "Delete from FlightInfo where ID=" + flID;
                cmd.CommandText = query;
                conn.Open();
                cmd.ExecuteScalar();
            }

            catch (Exception ex)
            {
                String msg = ex.Message.ToString();
                String caption = "Error!";
                MessageBox.Show(caption, msg, MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            finally
            {
                conn.Close();
                cmd.Dispose();
            }
    }
    }

}

