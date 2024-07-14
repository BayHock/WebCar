using WebCar.Areas.Identity.Data;

namespace WebCar.Models
{
    public class ChatUserModel
    {        
        public string ChatUserId { get; set; } //Primary key и внешний ключ к Id - таблица AspNetUsers
        public string UserNameActualChatUser { get; set; }

        public WebCarUser WebCarUser1 { get; set; }
        public WebCarUser WebCarUser2 { get; set; }
    }
}
