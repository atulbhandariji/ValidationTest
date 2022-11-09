using System.ComponentModel.DataAnnotations;

namespace ValidationTest.Models
{


    public class UserDetails
    {
        public int UserId { get; set; }




        public string Name { get; set; }    

        public string Email { get; set; }

        public string Address { get; set; }

        public string MobileNo { get; set; }   

        public string Country { get; set; }

        public string State { get; set; }

        public string Course { get; set; }  

        public string City { get; set; }
        public string EnterBy { get; set; }

        public int CountryId { get; set; }
        public int StateId { get; set; }
        public int CityId { get; set; }


    }


    public class CountryDetails
    {
    public int CountryId { get; set; }
    
    public string CountryName { get; set; } 
    }

}
