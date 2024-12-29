using System.ComponentModel;

namespace money_management_service.Enums
{
    public enum CardType
    {
        [Description("Tiết kiệm")]
        SAVING,

        [Description("Sinh hoạt")]
        LIVING,

        [Description("Đầu tư")]
        INVEST,
    }
}
