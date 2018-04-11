﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageService.Logging.Modal
{
    public class MessageRecievedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public MessageTypeEnum Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Message { get; set; }

        public MessageRecievedEventArgs(MessageTypeEnum status, string message)
        {
            this.Status = status;
            this.Message = message;
        }
    }
}