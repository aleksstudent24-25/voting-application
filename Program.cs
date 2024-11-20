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
}
);

app.Run();
