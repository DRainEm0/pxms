namespace BackendApi.Contracts.Account
{
    public class GetUserResponse
    {
        public int UserID { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Photo { get; set; } = null!;
        public int Phone { get; set; }
    }
}
