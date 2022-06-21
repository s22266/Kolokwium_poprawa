﻿namespace Kolokwium_poprawa.Models
{
    public class File
    {
        public int  FileID { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public int TeamID { get; set; }
        public virtual Team Team { get; set; }
    }
}
