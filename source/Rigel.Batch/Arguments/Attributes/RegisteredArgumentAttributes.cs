using System;
using System.Collections.Generic;
using Rigel.Batch.Arguments.Attributes.Customized.Boolean;
using Rigel.Batch.Arguments.Attributes.Customized.Date;
using Rigel.Batch.Arguments.Attributes.Customized.Directories;
using Rigel.Batch.Arguments.Attributes.Customized.Filenames;
using Rigel.Batch.Arguments.Attributes.Customized.Integer;
using Rigel.Batch.Arguments.Attributes.Customized.String;

namespace Rigel.Batch.Arguments.Attributes
{
    public class RegisteredArgumentAttributes
    {
        private static readonly IDictionary<string, Type> _argumentTokens = new Dictionary<string, Type>();

        #region Argument Token Initialization

        public static IDictionary<string, Type> FetchRegisteredArgumentTokens()
        {
            AddBooleanAttributes();
            AddDateAttributes();
            AddDecimalAttributes();
            AddDirectoryAttributes();
            AddFileAttributes();
            AddIntegerAttributes();
            AddStringAttributes();

            return _argumentTokens;
        }

        private static void AddBooleanAttributes()
        {
            AddTokens(typeof(DownloadDataAttribute), "downloaddata", "dd");
        }

        private static void AddDateAttributes()
        {
            AddTokens(typeof(RunAsDateAttribute), "runasdate");
            AddTokens(typeof(EndDateAttribute), "enddate");
            AddTokens(typeof(StartDateAttribute), "startdate");
        }

        private static void AddDecimalAttributes()
        {
        }

        private static void AddDirectoryAttributes()
        {
            AddTokens(typeof(InputDirectoryAttribute), "inputfolder", "inputdirectory");
            AddTokens(typeof(WorkingDirectoryAttribute), "w", "work", "workingfolder", "workingdirectory", "processingpath");
            AddTokens(typeof(SecondInputDirectoryAttribute), "inputfolder2", "inputdirectory2");
        }

        private static void AddFileAttributes()
        {
            AddTokens(typeof(FlatFilenameAttribute), "ffd", "flatfiledefn", "flatfiledefinition");
            AddTokens(typeof(InputFilenameAttribute), "i", "in", "input", "inputfile", "inputfilename");
            AddTokens(typeof(OutputFilenameAttribute), "o", "out", "output", "outputFile", "outputFileName");
            AddTokens(typeof(SecondInputFilenameAttribute), "i2", "in2", "input2", "inputfile2", "inputfilename2");
            AddTokens(typeof(SecondOutputFilenameAttribute), "o2", "out2", "output2", "outputFile2", "outputFileName2");
            AddTokens(typeof(ThirdOutputFilenameAttribute), "o3", "out3", "output3", "outputFile3", "outputFileName3");
        }

        private static void AddIntegerAttributes()
        {
            AddTokens(typeof(EmailLevelAttribute), "emaillevel");
        }

        private static void AddStringAttributes()
        {
            AddTokens(typeof(BatchNameAttribute), "b", "batch", "batchname");
            AddTokens(typeof(EmailSenderAttribute), "emailsender");
            AddTokens(typeof(EmailRecipientsAttribute), "emailrecipients");
        }

        #endregion

        private static void AddTokens(Type type, params string[] tokens)
        {
            if((_argumentTokens != null) && (type != null) && (tokens != null) && (tokens.Length > 0))
            {
                foreach(var token in tokens)
                {
                    _argumentTokens.Add(token, type);
                }
            }
        }
    }
}