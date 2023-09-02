namespace WebApiAspNetCore.Entities
{
    public class AccountEntity
    {
        public int Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string ContactNum { get; set; }
        public string AccType { get; set; }
        public bool IsSubscribed { get; set; }
        public DateTime AccCreated { get; set; }

    }
}
