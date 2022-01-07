namespace Profile.Domain.Profile;

public class Profile
{
    public Guid Id { get; set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public ProfileType Type { get; set; }

    public Profile(ProfileType type)
    {
        Id = Guid.NewGuid();
        Type = type;
    }


    public void SetFirstName(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new Exception("First name can not be null or white space");
        
        FirstName = firstName;
    }

    public void SetLastName(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
            throw new Exception("Last name can not be null or white space");
        
        LastName = lastName;
    }
}

public enum ProfileType
{
    Profile,
    Company
}