List<string> nomineeNames = [
    "Lars",
    "Joakim",
    "Dracula",
];

Election election = new Election(nomineeNames);

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/election/nominees", () =>
{
    return election.ListNominees();
});

app.MapPost("/election/vote", (VoteDTO castVote) =>
{
    Vote? voteReceipt = election.CastVote(castVote.NomineeName);
    if (voteReceipt == null) return Results.BadRequest();
    return Results.Ok(voteReceipt);
});
app.Run();
