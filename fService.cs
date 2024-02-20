using QuanLyKhachSan.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class fService : Form
    {
        BindingSource ServiceList = new BindingSource();
        public fService()
        {
            InitializeComponent();
            LoadList();
        }

        void LoadList()
        {
            dgvService.DataSource = ServiceList;
            LoadService();
            AddServiceBinding();
        }
        void LoadService()
        {
            string query = "USP_GetService";
            ServiceList.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }
        void AddServiceBinding()
        {
            txbIDService.DataBindings.Add(new Binding("Text", dgvService.DataSource, "id", true, DataSourceUpdateMode.Never));
            txbNameService.DataBindings.Add(new Binding("Text", dgvService.DataSource, "NameService", true, DataSourceUpdateMode.Never));
            txbPriceService.DataBindings.Add(new Binding("Text", dgvService.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            string nameService = txbNameService.Text;
            float priceService = (float)txbPriceService.Value;
            if (ServiceDAO.Instance.InsertService(nameService, priceService))
            {
                MessageBox.Show("Thêm dịch vụ thành công");
                LoadService();
            }
            else
            {
                MessageBox.Show("Có lỗi khi thêm dịch vụ");
            }
        }

        private void btnRepairService_Click(object sender, EventArgs e)
        {
            string nameService = txbNameService.Text;
            float priceService = (float)txbPriceService.Value;
            int idService = int.Parse(txbIDService.Text.Trim());
            if (ServiceDAO.Instance.UpdateService(nameService, priceService,idService))
            {
                MessageBox.Show("Sửa dịch vụ thành công");
                LoadService();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Sửa dịch vụ");
            }
        }

        private void btnDeleteService_Click(object sender, EventArgs e)
        {
            int idService = int.Parse(txbIDService.Text.Trim());
            if (ServiceDAO.Instance.DeleteService(idService))
            {
                MessageBox.Show("Xoá dịch vụ thành công");
                LoadService();
            }
            else
            {
                MessageBox.Show("Có lỗi khi Xoá dịch vụ");
            }
        }
    }
}
