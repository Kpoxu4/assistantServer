namespace assistantServer.data.model
{
    public class User : BaseModel
    {
        public string Name {  get; set; }
        public string Phone {  get; set; }
        public string Password { get; set; }
        public string? Token { get; set; }
        public virtual  List<Order>? Orders { get; set; }
    }
}
