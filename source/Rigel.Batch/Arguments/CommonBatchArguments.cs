using System;
using Rigel.Batch.Arguments.Attributes.Customized.Date;
using Rigel.Batch.Arguments.Attributes.Customized.Directories;
using Rigel.Batch.Arguments.Attributes.Customized.Integer;
using Rigel.Batch.Arguments.Attributes.Customized.String;

namespace Rigel.Batch.Arguments
{
    public class CommonBatchArguments
    {
        protected string _workingDirectory;
        protected DateTime _runAsDate;
        protected int _emailLevel;
        protected string _emailSender;
        protected string _emailRecipients;

        [WorkingDirectory(true, true, true)]
        public string WorkingDirectory
        {
            get { return _workingDirectory; }
            set { _workingDirectory = value; }
        }

        [RunAsDate(true, true)]
        public DateTime RunAsDate
        {
            get { return _runAsDate; }
            set { _runAsDate = value; }
        }
    }
}