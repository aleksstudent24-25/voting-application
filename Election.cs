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
}

class Nominee
{
    public string Name;

    public Nominee(string name)
    {
        Name = name;
    }
}

class Vote
{
    Nominee CastFor;
    DateTime CastAt;

    public Vote(Nominee nominee)
    {
        CastFor = nominee;
        CastAt = DateTime.Now;
    }
}