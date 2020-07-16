using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CushyTripV1.Class
{
    class TourPackageUtility
    {
        public static bool CreateTourPackage(string json,string typeOfPackage,string method)
        {
            string api = GetApiUrl(typeOfPackage);

           
           
            RestClient rClient = new RestClient();
            rClient.endPoint = api;

            switch (method)
            {
                case "POST":
                    rClient.httpMethod = httpVerb.POST;
                    rClient.postJSON = json;
                    break;
                default:
                    rClient.httpMethod = httpVerb.GET;
                    break;
            }

            string strResponse = string.Empty;
            strResponse = rClient.makeRequest();

            return true;
        }
        
        private static string GetApiUrl(string typeOfPackage)
        {
            switch (typeOfPackage)
            {
                case "Regular":
                    return  "http://192.168.1.21:3000/api/tourPackages/createRegularPackage";
                    
                case "Joiner":
                    return  "http://192.168.1.21:3000/api/tourPackages/createJoinerPackage";
                default:
                    return null;
            }
        }
    }
}
