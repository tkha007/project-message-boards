namespace ProjectMessageBoards.Domain;

public sealed record Message(User User, string Content, DateTime PostDateUtc);
