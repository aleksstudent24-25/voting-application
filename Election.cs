class Election
{
    List<Nominee> Nominees { get; }
    List<Vote> CastVotes { get; }

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

    public Vote? CastVote(string name)
    {
        Nominee? nominee = Nominees.Find((nominee) => nominee.Name.ToLower() == name.ToLower());
        if (nominee == null) return null;

        Vote newVote = new Vote(nominee);
        CastVotes.Add(newVote);

        return newVote;
    }

    public Result GetCurrentResult()
    {
        Result result = new(CastVotes);
        return result;
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
    public DateTime CastAt { get; }
    public Nominee CastFor { get; }

    public Vote(Nominee nominee)
    {
        CastFor = nominee;
        CastAt = DateTime.Now;
    }
}

class Result
{
    public Dictionary<string, int> NomineesVoteCount { get; }

    public Result(List<Vote> votes)
    {
        NomineesVoteCount = [];

        foreach (var vote in votes)
        {
            if (!NomineesVoteCount.ContainsKey(vote.CastFor.Name))
                NomineesVoteCount.Add(vote.CastFor.Name, 1);
            else
                NomineesVoteCount[vote.CastFor.Name]++;
        }
    }
}