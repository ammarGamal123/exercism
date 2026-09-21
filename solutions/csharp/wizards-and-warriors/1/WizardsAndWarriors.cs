abstract class Character
{
    private string characterType;
    protected Character(string characterType)
    {
        this.characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return "Character is a ";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {

    }

    public override int DamagePoints(Character target)
    {
        if (target.Vulnerable())
        {
            return 10;
        }
        return 6;
    }
    public override string ToString()
    {
        return base.ToString() + "Warrior";
    }

}

class Wizard : Character
{
    private bool spellPrepared = false;
    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        if (spellPrepared)
        {
            return 12;
        }
        else return 3;
    }

    public void PrepareSpell()
    {
        spellPrepared = true; 
    }

    public override bool Vulnerable()
    {
        return !spellPrepared;
    }


    public override string ToString()
    {
        return base.ToString() + "Wizard";
    }

}
