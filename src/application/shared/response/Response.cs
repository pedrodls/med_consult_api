namespace med_consult_api.src.application;


public class Response
{
    public Guid Id { get; set; }
    public string Message { get; set; }

    public Response(Guid id, string message)
    {
        Id = id;
        Message = message;
    }

    public static Response Create(Guid id, string message)
    {
        return new Response(id, message);
    }
}