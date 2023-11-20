namespace HouseApp.Contracts;

public class DefaultResponse
{
    public bool Accepted { get; set; } = true;

    public static DefaultResponse Succeed => new DefaultResponse();
}