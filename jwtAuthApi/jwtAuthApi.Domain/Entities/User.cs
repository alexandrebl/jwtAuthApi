using jwtAuthApi.Domain.Entities.Base;

namespace jwtAuthApi.Domain.Entities
{
    public sealed class User : Entity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public override string SearchKey => UserName;
    }
}