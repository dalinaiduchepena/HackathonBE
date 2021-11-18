using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using WelfareScheme.Concrete_Classs;
using WelfareScheme.Model;

namespace WelfareScheme.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchemeController : ControllerBase
    {

        private readonly ILogger<SchemeController> _logger;
        private Ischeme _scheme;

        public SchemeController(ILogger<SchemeController> logger, Ischeme scheme)
        {
            _logger = logger;
            _scheme = scheme;
        }


        [HttpGet("ExtractWebsite")]
        public async Task<IActionResult> ExtractWebsite()
        // public async Task<string[]> GetAsync()
        {
            ////able to get raw data in console
            SingleResponse<List<SchemeModel>> response = new SingleResponse<List<SchemeModel>>();
            HtmlAgilityPack.HtmlWeb web = new HtmlAgilityPack.HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = web.Load("https://pib.gov.in/PressReleaseIframePage.aspx?PRID=1608345");
            var val = doc.DocumentNode.SelectNodes("//div[@class ='innner-page-main-about-us-content-right-part']").ToList();
            var sw = new StringWriter();
            foreach (var item in val)
            {
                Console.SetOut(sw);
                Console.SetError(sw);
                Console.WriteLine(item.InnerText);
            }
            //var value = Console.ReadLine();
            string result = sw.ToString();
            //string[] words1 = Regex.Split(result, @"\W+");
            //return Ok(result);
            response.Model = await _scheme.GetSchemeDetails(result.ToLower());
            return Ok(response);
        }

        //[HttpGet("GetBenificiaries/Result/{result}")]
        //public async Task<IActionResult> GetBenificiaries(string result)
        //{
        //    SingleResponse<string> response = new SingleResponse<string>();
        //    string[] beneficiariesList = await _scheme.GetBeneficiaryList(result.ToLower());

        //    foreach (string str in beneficiariesList)
        //    {
        //        Console.WriteLine(str);
        //    }

        //    //return Ok(beneficiariesList);
        //    return response.ToHttpResponse();
        //}
    }
}
