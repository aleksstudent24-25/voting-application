class Election
{
    List<Nominee> Nominees;
    List<Vote> CastVotes;

    public Election(List<string> nomineeNames)
    {
        Nominees = new List<Nominee>();
        CastVotes = new List<Vote>();

        foreach (var name in nomineeNames)
        {
            Nominees.Add(new Nominee(name));
        }
    }

    public List<Nominee> ListNominees()
    {
        return Nominees;
    }
}

class Nominee
{
    public string Name { get; }

    public Nominee(string name)
    {
        Name = name;
    }
}

class Vote
{
    DateTime CastAt { get; }
    Nominee CastFor { get; }

    public Vote(Nominee nominee)
    {
        CastFor = nominee;
        CastAt = DateTime.Now;
    }
}