using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3_Haotian_Zhang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Validate();
                this.productsBindingSource.EndEdit();
                this.tableAdapterManager.UpdateAll(this.northwindDataSet);
            }
            catch (DBConcurrencyException)
            {
                MessageBox.Show("Another user changed data in the meantime, Try again!");
                this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            }
            catch (NoNullAllowedException ex)
            {
                MessageBox.Show("Please input data!, Try again!" + ex.Message+ex.Data.Values);
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Database error while saving data:" + ex.Message);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Other error while saving data: " + ex.Message);
            }
            finally
            {
                this.productsTableAdapter.Fill(this.northwindDataSet.Products);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                this.categoriesTableAdapter.Fill(this.northwindDataSet.Categories);
                this.suppliersTableAdapter.Fill(this.northwindDataSet.Suppliers);
                this.order_DetailsTableAdapter.Fill(this.northwindDataSet.Order_Details);
                this.productsTableAdapter.Fill(this.northwindDataSet.Products);

            }
            catch(SqlException ex)
            {
                MessageBox.Show("Database error while saving data:" + ex.Message);

            }
            catch(Exception ex)
            {
                MessageBox.Show("Other error while saving data: " + ex.Message);
            }
        }
    }
}
