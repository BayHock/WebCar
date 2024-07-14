using Microsoft.AspNetCore.Identity;
using WebCar.Models;

namespace WebCar.Areas.Identity.Data;

// Add profile data for application users by adding properties to the WebCarUser class
public class WebCarUser : IdentityUser
{
    public ICollection<ChatUserModel> ChatUserModels1 { get; set; }
    public ChatUserModel ChatUserModel2 { get; set; }
}

