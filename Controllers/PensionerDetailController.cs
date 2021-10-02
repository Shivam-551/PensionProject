using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using static PensionProject.PensionerDetail;



namespace PensionProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PensionerDetailController : ControllerBase
    {
        // GET: api/<PensionDetailController>
        private IConfiguration configuration;
        public PensionerDetailController(IConfiguration iconfig)
        {
            configuration = iconfig;
        }
        [HttpGet("{aadhar}")]
        public PensionerDetail GetDetailsByAadhar(string aadhar)
        {
            List<PensionerDetail> pensionerDetail = GetDetails();

            return pensionerDetail.FirstOrDefault(x => x.AadharNumber == aadhar);
        }

        private List<PensionerDetail> GetDetails()
        {
            List<PensionerDetail> pensionerDetails = new List<PensionerDetail>();
            try
            {
                string csvConn = configuration.GetValue<string>("FilePath:CsvConnection");
                using (StreamReader sr = new StreamReader(csvConn))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] values = line.Split(',');
                        pensionerDetails.Add(new PensionerDetail
                        {
                            Name = values[0],
                            DateOfBirth = (values[1]),
                            PAN = values[2],
                            AadharNumber = values[3],
                            SalaryEarned = Convert.ToInt32(values[4]),
                            Allowances = Convert.ToInt32(values[5]),
                            PensionType = (PensionTypeDetail)Enum.Parse(typeof(PensionTypeDetail), values[6]),
                            BankName = values[7],
                            AccountNumber = values[8],
                            BankType = (BankTypeDetail)Enum.Parse(typeof(BankTypeDetail), values[9])
                        });

                    }
                }

            }
            catch (NullReferenceException e)
            {
                Console.Out.Write(e);
                return null;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e);
                return null;

            }

            return pensionerDetails.ToList();

        }
    }

}