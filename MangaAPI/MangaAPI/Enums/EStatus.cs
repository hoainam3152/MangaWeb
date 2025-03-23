using System.ComponentModel;

namespace MangaAPI.Enums
{
    public enum EStatus
    {
        [Description("Đang Cập Nhật")]
        UPDATING,
        [Description("Hoàn Thành")]
        COMPLETED,
        [Description("Tạm Ngưng")]
        HIATUS,
        [Description("Bị Huỷ")]
        CANCELLED,
        [Description("Đã Dịch Xong")]
        FULLY_TRANSLATED,
        [Description("Chưa Hoàn Thành Dịch")]
        ONGOING_TRANSLATION,
        [Description("Ngừng Dịch")]
        DROP
    }
}
