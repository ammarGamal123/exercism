public class FacialFeatures
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }
    // TODO: implement equality and GetHashCode() methods
    public override bool Equals(object? obj)
    {

        if (obj is not FacialFeatures other)
            return false;

        return EyeColor == other.EyeColor && 
            PhiltrumWidth == other.PhiltrumWidth;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }


}

public class Identity
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }


    public override bool Equals(object? obj)
    {
        if (obj is not Identity other)
            return false;

        return Email == other.Email && 
            Equals(FacialFeatures, other.FacialFeatures);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Email, FacialFeatures);
    }



    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    // TODO: implement equality and GetHashCode() methods
}

public class Authenticator
{
    private Dictionary<Identity, bool> mp = new();
    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.EyeColor == faceB.EyeColor && faceA.PhiltrumWidth == faceB.PhiltrumWidth;
    }

    public bool IsAdmin(Identity identity)
    {
        var email = "admin@exerc.ism";
        Identity ideal = new Identity(email, new FacialFeatures("green", 0.9m));

        return identity.Email == ideal.Email && identity.FacialFeatures.EyeColor == ideal.FacialFeatures.EyeColor && identity.FacialFeatures.PhiltrumWidth == ideal.FacialFeatures.PhiltrumWidth;
    }

    public bool Register(Identity identity)
    {
        if (mp.Count == 0)
        {
            mp.Add(identity, true);
            return true;
        }
        else
        {
            return false;
        }
    } 
    public bool IsRegistered(Identity identity)
    {
        if (mp.Count == 0 || !mp.ContainsKey(identity))
            return false;

        return true;
    }

    public static bool AreSameObject(Identity identityA, Identity identityB)
    {
        return identityA == identityB;
    }
}
