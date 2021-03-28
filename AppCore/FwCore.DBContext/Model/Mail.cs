using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DBContext.Model
{
  public  class Mail
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
