using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DHLWebAPI.Models.DTOs
{
    public class TblToolsDTO
    {
        public string IdTool { get; set; }
        public string ToolName { get; set; }
        public byte[] ToolKey { get; set; }
        public bool ToolStatus { get; set; }
        public int IdProfile { get; set; }
    }
}
