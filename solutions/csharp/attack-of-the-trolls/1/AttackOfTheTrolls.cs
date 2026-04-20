// TODO: define the 'AccountType' enum

enum AccountType
{
    Guest, 
    User, 
    Moderator
}



// TODO: define the 'Permission' enum
[Flags]
enum Permission : byte
{
    Read = 0b00000001, 
    Write = 0b00000010, 
    Delete = 0b000000100,
    All = 0b000000111,
    None = 0b00000000
}

static class Permissions
{
    public static Permission Default(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Guest => Permission.Read,
            AccountType.User => Permission.Read | Permission.Write,
            AccountType.Moderator => Permission.All,

            _ => Permission.None
        };

    }

    public static Permission Grant(Permission current, Permission grant)
    {
        current |= grant;

        return current;
    }

    public static Permission Revoke(Permission current, Permission revoke)
    {
        if (revoke == Permission.All) 
            return Permission.None;

        current = (current & (~revoke));
        
        return current;
    }

    public static bool Check(Permission current, Permission check)
    {
        return (current & check) == check;
    }
}
