public struct Identity
{
    public string Email { get; set; }
    public string EyeColor { get; set; }
}

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Grey = "grey";
    }



    private readonly Identity admin;

    public Authenticator(Identity admin)
    {
        this.admin = admin;
    }

    private readonly IDictionary<string, Identity> developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new Identity
            {
                Email = "bert@ex.ism",
                EyeColor = "blue"
            },

            ["Anders"] = new Identity
            {
                Email = "anders@ex.ism",
                EyeColor = "brown"
            }
        };

    public Identity Admin
    {
        get { return admin; }
    }

    public IDictionary<string, Identity> GetDevelopers()
    {
        return new System.Collections.ObjectModel.ReadOnlyDictionary<string, Identity>(developers);
    }
}
