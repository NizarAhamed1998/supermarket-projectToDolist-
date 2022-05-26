using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SuperMarket
{
    class Product
    {
        string path = "E:\\Database\\restaurentbilling\\product.txt";
        Dictionary<int, Product> dict = new Dictionary<int, Product>();

        int _productId;
        string _productName;
        string _productNetWeight;
        int _productRate;
        string _productManufactureDate;
        string _productExpiryDate;

      
        public int ProductId
        {
            get { return _productId; }
           
        }

        public string ProductName
        {
            get { return _productName; }
            
        }
        public string ProductNetWeight
        {
            get { return _productNetWeight; }
            set { _productNetWeight = value; }
        }
        public int ProductRate
        {
            get { return _productRate; }
            set { _productRate = value; }
        }
        public string ProductManufactureDate
        {
            get { return _productManufactureDate; }
            set { _productManufactureDate = value; }
        }
        public string ProductExpiryDate
        {
            get { return _productExpiryDate; }
            set { _productExpiryDate = value; }
        }
        public Product(int productid,string productname,string productnetweight,int productrate,string productmanufacturedate,string productexpirydate)
        {
            this._productId = productid;
            this._productName = productname;
            ProductNetWeight = productnetweight;
            ProductRate = productrate;
            ProductManufactureDate = productmanufacturedate;
            ProductExpiryDate = productexpirydate;
        }
        public Product()
        {

        }
        public void filetodict()
        {
            
            string[] get = File.ReadAllLines(path);
            foreach (string item in get)
            {
                Product pdt;
                string[] data = item.Split(',');
                pdt = new Product(Convert.ToInt32(data[0]), data[1], data[3], Convert.ToInt32(data[2]), data[4], data[5]);
                dict.Add(pdt.ProductId,pdt);
                
            }
        }
        public string display()
        {
            string x = "";
            x += "ProductID\tPtoductName\tProductRate\tProductNetWeight\tProductManufactureDate\tProductExpiryDate\n";
            foreach (Product item in dict.Values)
            {
                x+=item.ProductId+"\t\t"+item.ProductName+"\t\t"+item.ProductRate+"\t\t"+item.ProductNetWeight+"\t\t"+item.ProductManufactureDate+"\t\t"+item.ProductExpiryDate+"\n";
            }
            return x;
        }

        public void changevalue(int key, string name,string val)
        {
            if (dict.ContainsKey(key))
            {
                Product data = dict[key];
                if ("productnetweight"==name)
                {
                    data.ProductNetWeight = val;
                }
                else if ("productrate"==name)
                {
                    data.ProductRate =Convert.ToInt32(val);
                }
                else if ("productmfgdate"==name)
                {
                    data.ProductManufactureDate = val;
                }
                else if ("productexpdate"==name)
                {
                    data.ProductExpiryDate = val;
                }
            }
        }
        public void dicttofile()
        {
            string x = "";
            foreach (Product item in dict.Values)
            {
                x += item.ProductId + "," + item.ProductName + "," + item.ProductRate + "," + item.ProductNetWeight + "," + item.ProductManufactureDate + "," + item.ProductExpiryDate + "\n";
            }
            File.WriteAllText(path, x);
        }
    }
}
