using AutoMapper;
using MangaAPI.Enums;
using System.ComponentModel;

namespace MangaAPI.Helpers
{
    public class IntDescriptionConverter : IValueConverter<int, string>
    {
        private readonly Dictionary<int, string> _statusDescriptions = new Dictionary<int, string>
        {
            { 0, "Đang Cập Nhật" },
            { 1, "Hoàn Thành" },
            { 2, "Tạm Ngưng" },
            { 3, "Bị Huỷ" },
            { 4, "Đã Dịch Xong" },
            { 5, "Chưa Hoàn Thành Dịch" },
            { 6, "Ngừng Dịch" }
        };

        public string Convert(int source, ResolutionContext context)
        {
            if (_statusDescriptions.TryGetValue(source, out string description))
            {
                return description;
            }
            return source.ToString();
        }
    }
}
