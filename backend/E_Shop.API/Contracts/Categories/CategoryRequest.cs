using System.ComponentModel;

namespace E_Shop.API.Contracts.Categories
{
    public record CategoryRequest(
        string Name = "",
        string Description = ""
    );
}
