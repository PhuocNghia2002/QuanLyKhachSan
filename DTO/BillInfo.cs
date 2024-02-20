using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class BillInfo
    {
        public BillInfo(int id, int billID, int serviceID, int count, DateTime dateService)
        {
            this.ID = id;
            this.BillID = billID;
            this.ServiceID = serviceID; ;
            this.Count = count;
            this.DateService = dateService;
        }
        public BillInfo(DataRow row) //lấy từ các trường dữ liệu trong sql
        {
            this.ID = (int)row["id"];
            this.BillID = (int)row["idbill"];
            this.ServiceID = (int)row["idService"];
            this.Count = (int)row["intCount"];
            this.DateService = (DateTime)row["DateService"];
        }
        private DateTime dateService;
        private int count;
        private int foodID;
        private int billID;
        private int iD;
        public int Count { get => count; set => count = value; }
        public int ServiceID { get => foodID; set => foodID = value; }
        public int BillID { get => billID; set => billID = value; }
        public int ID { get => iD; set => iD = value; }
        public DateTime DateService { get => dateService; set => dateService = value; }
    }
}
