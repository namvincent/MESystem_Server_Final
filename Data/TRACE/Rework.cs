﻿namespace MESystem.Data.TRACE
{
    public class Rework
    {
        public string? ReworkID { get; set; }
        public int? NG_Code { get; set; }
        public string? NG_Description_Eng { get; set; }
        public string? NG_Description_VN { get; set; }
        public string? Barcode { get; set; }
        public string? Customer_Barcode { get; set; }
        public DateTime? Input_Date { get; set; }
        public string? Contract { get; set; }
        public string? PartNo { get; set; }
        public string? Order_No { get; set; }
        public string? User_Id { get; set; }
        public string? Remark { get; set; }
        public string? Area { get; set; }

        public Rework(string? reworkID, string? barcode, string? customer_Barcode, int? nG_Code, DateTime? input_Date, string? remark, string? contract, string? partNo, string? order_No, string? user_Id, string? nG_Description_Eng, string? nG_Description_VN) : this(reworkID)
        {
            Barcode = barcode;
            Customer_Barcode = customer_Barcode;
            NG_Code = nG_Code;
            Input_Date = input_Date;
            Remark = remark;
            Contract = contract;
            PartNo = partNo;
            Order_No = order_No;
            User_Id = user_Id;
            NG_Description_Eng = nG_Description_Eng;
            NG_Description_VN = nG_Description_VN;
        }

        public Rework(string? barcode, string? customer_Barcode, int? nG_Code, string? remark, string? part_No, string? order_No, string? user_Id, string? area)
        {
            Barcode = barcode;
            Customer_Barcode = customer_Barcode;
            NG_Code = nG_Code;
            Remark = remark;
            PartNo = part_No;
            Order_No = order_No;
            User_Id = user_Id;
            Area = area;
        }

        public Rework(int? nG_Code, string? nG_Description_Eng, string? nG_Description_VN)
        {
            NG_Code = nG_Code;
            NG_Description_Eng = nG_Description_Eng;
            NG_Description_VN = nG_Description_VN;
        }

        public Rework()
        {

        }

        public Rework(string? nG_Description_VN)
        {
            NG_Description_VN = nG_Description_VN;
        }

        public Rework(int? nG_Code)
        {
            NG_Code = nG_Code;
        }
    }
}
