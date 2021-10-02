using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionProject
{
    public class PensionerDetail
    {
        public string Name { get; set; }
        public string DateOfBirth { get; set; }
        public string PAN { get; set; }
        public string AadharNumber { get; set; }
        public int SalaryEarned { get; set; }
        public int Allowances { get; set; }

        public PensionTypeDetail PensionType { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }

        public BankTypeDetail BankType { get; set; }

        public enum PensionTypeDetail
        {
            Self = 1,
            Family = 2
        }

        public enum BankTypeDetail
        {
            Public = 1,
            Private = 2
        }
    }
}
