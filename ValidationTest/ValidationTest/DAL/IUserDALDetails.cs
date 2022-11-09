using ValidationTest.Models;

namespace ValidationTest.DAL
{
    public interface IUserDALDetails
    {
        List<UserDetails> GetUserList();

        List<CountryDetails> GetCountryDetails();
    }
}
