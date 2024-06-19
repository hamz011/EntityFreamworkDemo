using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ProductDal _productDal = new ProductDal();
        void LoadProducts()
        {
            dgwProducts.DataSource = _productDal.GetALL();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = "Entity FreamWork Database";
            dgwProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgwProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            LoadProducts();
        }

        private void dgwProducts_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                tbxIdU.Text = dgwProducts.CurrentRow.Cells["Id"].Value.ToString();
                tbxIdD.Text = dgwProducts.CurrentRow.Cells["Id"].Value.ToString();
                tbxNameU.Text = dgwProducts.CurrentRow.Cells["Name"].Value.ToString();
                tbxUnitU.Text = dgwProducts.CurrentRow.Cells["Unit"].Value.ToString();
                tbxStockU.Text = dgwProducts.CurrentRow.Cells["StockAmount"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new Product
            {
                Name = tbxName.Text,
                StockAmount = Convert.ToInt32(tbxStock.Text),
                Unit = Convert.ToDecimal(tbxUnit.Text)
            });
            LoadProducts();
            MessageBox.Show("New product added!");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new Product { Id = Convert.ToInt32(tbxIdD.Text) });
            LoadProducts();
            MessageBox.Show("Product deleted!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new Product
            {
                Id = Convert.ToInt32(tbxIdU.Text),
                Name = tbxNameU.Text,
                StockAmount = Convert.ToInt32(tbxStockU.Text),
                Unit = Convert.ToDecimal(tbxUnitU.Text)
            });
            LoadProducts();
            MessageBox.Show("Product updated!");
        }
    }
}
