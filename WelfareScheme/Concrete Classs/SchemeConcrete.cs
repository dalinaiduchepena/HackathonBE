using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WelfareScheme.Model;

namespace WelfareScheme.Concrete_Classs
{
    public class SchemeConcrete : Ischeme
    {
        public async Task<SchemeModel> GetSchemeDetails(string words)
        {
            var schemeModel = new SchemeModel();
            string[] SchemeName = { "Pradhan", "Mantri", "Garib", "Kalyan", "Yojana" } ;
            string[] Names = (SchemeName.Where(a => words.Contains(a.ToLower()))).ToArray();
            schemeModel.SchemeName = string.Concat(Names);
            string SchemeUrl = "https://pib.gov.in/PressReleaseIframePage.aspx?PRID=1608345";
            schemeModel.SchemeLink = SchemeUrl;
            string Scheme = "Central";
            schemeModel.StateCentralScheme = Scheme;
            string[] beneficiaries = { "BC/ MBC", "SC/ ST",
                    "Handloom Weaver",
                    "farmers",
                    "Manufacturers",
                    "Nation Cadet Crops",
                    "Pregnant Women",
                    "Students",
                    "Transgender",
                    "Widow",
                    "Citizen",
                    "Government Employees",
                    "Journalists",
                    "Minorities",
                    "Physically Challenged",
                    "Senior Citizens",
                    "Teacher",
                    "Unemployed",
                    "Differently abled",
                    "Tribal",
                    "Sports",
                    "Player",
                    "athlete",
                    "Co-operation",
                    "Handicrafts",
                    "orphan",
                    "Patients" };
            
            string[] wro = (beneficiaries.Where(a => words.Contains(a.ToLower()))).ToArray();
            schemeModel.BenificiarieCriteria = String.Join(",", wro);
            string[] Description = { "Insurance cover of Rs 50 Lakh per health worker fighting COVID-19 to be provided under Insurance Scheme",
"80 crore poor people will to get 5 kg wheat or rice and 1 kg of preferred pulses for free every month for the next three months",
"20 crore women Jan Dhan account holders to get Rs 500 per month for next three months",
"Increase in MNREGA wage to Rs 202 a day from Rs 182 to benefit 13.62 crore families",
"An ex - gratia of Rs 1, 000 to 3 crore poor senior citizen, poor widows and poor disabled",
"Government to front - load Rs 2, 000 paid to farmers in first week of April under existing PM Kisan Yojana to benefit 8.7 crore farmers",
"Central Government has given orders to State Governments to use Building and Construction Workers Welfare Fund to provide relief to Construction Workers" };

            string[] desc = (Description.Where(a => words.Contains(a.ToLower()))).ToArray();
            schemeModel.SchemeDescription = String.Join(",", desc);
            return schemeModel;
        }

        public static async Task<string[]> GetDocumentsNeeded(string words)
        {
            string[] beneficiaries = { "BC/ MBC certificate",
                                        "SC/ ST certificate",
                                        "Vaccination Certificate",
                                        "Aadhar Card",
                                        "Driving License","Pan Card",
                                        "SSLC certificate",
                                        "HSC certificate",
                                        "Passport",
                                        "Ration Card"};
            string[] wro = (beneficiaries.Where(a => words.Contains(a.ToLower()))).ToArray();
            return wro;
        }

        //ddmmyyyyy
        public async Task<List<DateTime>> GetDateDetails(string words)
        {
            var regex = new Regex(@"\b\d{2}[- /.]\d{2}[- /.]\d{4}\b");
            List<DateTime> dateDetails = new List<DateTime>();
            foreach (Match m in regex.Matches(words))
            {
                DateTime dt;
                if (DateTime.TryParseExact(m.Value, "dd.MM.yyyy", null, DateTimeStyles.None, out dt))
                {
                    dateDetails.Add(dt);
                }
                else if (DateTime.TryParseExact(m.Value, "dd/MM/yyyy", null, DateTimeStyles.None, out dt))
                {
                    dateDetails.Add(dt);
                }
                else if (DateTime.TryParseExact(m.Value, "dd-MM-yyyy", null, DateTimeStyles.None, out dt))
                {
                    dateDetails.Add(dt);
                }
            }
            dateDetails.Sort();
            return dateDetails;
        }
    }
}
