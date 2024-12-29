using System.ComponentModel;

namespace money_management_service.Core.Enums
{
    public enum Status
    {
        [Description("Hoạt động")]
        ACTIVE,

        [Description("Tạm khóa")]
        INACTIVE,

        [Description("Xóa vĩnh viễn")]
        DELETED
    }
}
