using LinqToExcel;
using LinqToExcel.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToExcelSample
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ATPrice> priceList = null;
            using (var excel = new ExcelQueryFactory(@"C:\Users\PC\Desktop\priceESO.xlsx"))
            {
                priceList = from p in excel.Worksheet<ATPrice>("PriceESO").ToList()
                            select new ATPrice
                            {
                                Brand = p.Brand,
                                Code = p.Code,
                                CatologeCode = p.CatologeCode,
                                FullName = p.FullName,
                                QuantityBrovary1 = p.QuantityBrovary1,
                                QuantityDnepr1 = p.QuantityDnepr1,
                                QuantityHarciv1 = p.QuantityHarciv1,
                                QuantityKiev1 = p.QuantityKiev1,
                                QuantityKiev2 = p.QuantityKiev2,
                                QuantityPoltava1 = p.QuantityPoltava1,
                                UnitPrice = p.UnitPrice
                            };
            }

            foreach (var item in priceList)
            {
                Console.WriteLine($"{item.Brand}\t{item.FullName}\t{item.UnitPrice}");
            }
        }
    }

    class ATPrice
    {
        [ExcelColumn("Бренд")]
        public string Brand { get; set; }
        [ExcelColumn("Код")]
        public string Code { get; set; }
        [ExcelColumn("Код Товара Производителя")]
        public string CatologeCode { get; set; }
        [ExcelColumn("Наименование")]
        public string FullName { get; set; }
        [ExcelColumn("Цена закупки")]
        public string UnitPrice { get; set; }
        [ExcelColumn("КИЕВ1")]
        public string QuantityKiev1 { get; set; }
        [ExcelColumn("КИЕВ2")]
        public string QuantityKiev2 { get; set; }
        [ExcelColumn("БРВ1")]
        public string QuantityBrovary1 { get; set; }
        [ExcelColumn("Днепр1")]
        public string QuantityDnepr1 { get; set; }
        [ExcelColumn("ПЛТ1")]
        public string QuantityPoltava1 { get; set; }
        [ExcelColumn("ХРК1")]
        public string QuantityHarciv1 { get; set; }
    }
}
