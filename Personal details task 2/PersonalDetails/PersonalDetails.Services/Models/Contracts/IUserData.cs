namespace PersonalDetails.Services.Models.Contracts
{
    public interface IUserData 
    {
        string Id { get; set; }

        string Password { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }
    }
}
