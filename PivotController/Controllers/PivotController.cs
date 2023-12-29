using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Pivot.Engine;

namespace PivotController.Controllers
{
    [Route("api/[controller]")]
    public class PivotController : Controller
    {
        private PivotEngine<PivotViewData> PivotEngine = new PivotEngine<PivotViewData>();

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
            EngineProperties engine = await PivotEngine.GetEngine(param);
            Dictionary<string, object> returnValue = new Dictionary<string, object>();
            returnValue["memberName"] = param.MemberName;
            if (engine.FieldList[param.MemberName].IsMembersFilled)
            {
                returnValue["members"] = JsonConvert.SerializeObject(engine.FieldList[param.MemberName].Members);
            }
            else
            {
                await PivotEngine.PerformAction(engine, param);
                returnValue["members"] = JsonConvert.SerializeObject(engine.FieldList[param.MemberName].Members);
            }
            return returnValue;
        }

        private async Task<object> GetPivotValues(FetchData param)
        {
            List<PivotViewData> listData = new List<PivotViewData>();
            listData.Add(new PivotViewData
            {
                ProductID = "PRO-1",
                Year = (new string[] { "FY 2015", "FY 2016", "FY 2017", "FY 2018", "FY 2019" })[new Random().Next(5)],
                Country = (new string[] { "Canada", "France", "Australia", "Germany", "France" })[new Random().Next(5)],
                Product = (new string[] { "Car", "Van", "Bike", "Flight", "Bus" })[new Random().Next(5)],
                Price = 3.4 + 500,
                Sold = (15) + 10
            });
            PivotEngine.Data = listData;
            EngineProperties engine = await PivotEngine.GetEngine(param);
            Dictionary<string, object> result = PivotEngine.GetSerializedPivotValues();
            result["pivotCount"] = "";
            result["pivotValue"] = "";
            result["data"] = new PivotViewData().GetVirtualData(1000);
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

            public List<PivotViewData> GetVirtualData(int count)
            {
                List<PivotViewData> VirtualData = new List<PivotViewData>();

                for (int i = 1; i <= count; i++)
                {
                    PivotViewData p = new PivotViewData
                    {
                        ProductID = "PRO-" + (count + i),
                        Year = (new string[] { "FY 2015", "FY 2016", "FY 2017", "FY 2018", "FY 2019" })[new Random().Next(5)],
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
