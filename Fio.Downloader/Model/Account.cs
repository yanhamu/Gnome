using System;

namespace Fio.Downloader.Model
{
    public class Account
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime? LastSync { get; set; }
    }
}
