using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Pivot.Engine;
using System.Diagnostics.Metrics;
using System.Dynamic;

namespace PivotController.Controllers
{
    [Route("api/[controller]")]
    public class PivotController : Controller
    {
        private PivotEngine<ExpandoObject> PivotEngine = new PivotEngine<ExpandoObject>();

        [Route("/api/pivot/post")]
        [HttpPost]
        public async Task<object> Post([FromBody] object args)
        {
            FetchData param = JsonConvert.DeserializeObject<FetchData>(args.ToString());
            if (param.Action == "fetchFieldMembers")
            {
                return await GetMembers(param);
            }
            else
            {
                return await GetPivotValues(param);
            }
        }

        private async Task<object> GetMembers(FetchData param)
        {
            Dictionary<string, object> returnValue = new Dictionary<string, object>();
            if (param.MemberName == "Year")
            {
                returnValue["memberName"] = param.MemberName;
                Dictionary<string, Members> result = new Dictionary<string, Members>();
                result.Add("FY 2015", new Members()
                {
                    Caption = "FY 2015",
                    Name = "FY 2015",
                    IsSelected = true
                });
                result.Add("FY 2016", new Members()
                {
                    Caption = "FY 2016",
                    Name = "FY 2016",
                    IsSelected = true
                });
                result.Add("FY 2017", new Members()
                {
                    Caption = "FY 2017",
                    Name = "FY 2017",
                    IsSelected = true
                });
                result.Add("FY 2018", new Members()
                {
                    Caption = "FY 2018",
                    Name = "FY 2018",
                    IsSelected = true
                });
                returnValue["members"] = JsonConvert.SerializeObject(result);
            }
            return returnValue;
        }

        private async Task<object> GetPivotValues(FetchData param)
        {
            List<ExpandoObject> listData = new List<ExpandoObject>();
            dynamic d = new ExpandoObject();
            d.ProductID = "";
            d.Year = "";
            d.Country = "";
            d.Product = "";
            d.Price = 0;
            d.Sold = 0;
            listData.Add(d);
            PivotEngine.Data = listData;
            EngineProperties engine = await PivotEngine.GetEngine(param);
            Dictionary<string, object> result = PivotEngine.GetSerializedPivotValues();
            result["pivotCount"] = "";
            result["pivotValue"] = "";
            result["data"] = new PivotViewData().GetVirtualData(1000, param);
            return result;
        }

        public class PivotViewData
        {
            public string ProductID { get; set; }
            public string Country { get; set; }
            public string Product { get; set; }
            public double Sold { get; set; }
            public double Price { get; set; }
            public string Year { get; set; }

            public List<PivotViewData> GetVirtualData(int count, FetchData param)
            {
                List<PivotViewData> VirtualData = new List<PivotViewData>();

                for (int i = 1; i <= count; i++)
                {
                    PivotViewData p = new PivotViewData
                    {
                        ProductID = "PRO-" + (count + i),
                        Year = param.Action == "onFilter" ? param.FilterItem.Items[new Random().Next(param.FilterItem.Items.Length)] : (new string[] { "FY 2015", "FY 2016", "FY 2017", "FY 2018", "FY 2019" })[new Random().Next(5)],
                        Country = (new string[] { "Canada", "France", "Australia", "Germany", "France" })[new Random().Next(5)],
                        Product = (new string[] { "Car", "Van", "Bike", "Flight", "Bus" })[new Random().Next(5)],
                        Price = (3.4 * i) + 500,
                        Sold = (i * 15) + 10
                    };
                    VirtualData.Add(p);
                }
                return VirtualData;
            }
        }
    }
}