using System;
using System.Collections.Generic;
using Rigel.Core;

namespace Rigel.Batch
{
    public class BatchExecutableAttribute : Attribute
    {
        #region Variables

        /// These two are added for for batches that have muliple executable names.
        private string _alternateName;

        private string _alternateNameTriforce;
        private string _batchName;
        private string _legacyBatchName;

        #endregion

        #region Constructors

        public BatchExecutableAttribute(string batchName)
        {
            _batchName = batchName;
        }

        public BatchExecutableAttribute(string batchName, string legacyBatchName)
        {
            _batchName = batchName;
            _legacyBatchName = legacyBatchName;
        }

        public BatchExecutableAttribute(string batchName, string legacyBatchName, string alternateName, string alternateNameTriforce)
        {
            _batchName = batchName;
            _alternateNameTriforce = alternateNameTriforce;
            _alternateName = alternateName;
            _legacyBatchName = legacyBatchName;
        }

        #endregion

        #region Properties

        public string BatchName
        {
            get { return _batchName; }
            set { _batchName = value; }
        }

        public string LegacyBatchName
        {
            get { return _legacyBatchName; }
            set { _legacyBatchName = value; }
        }

        public string AlternateName
        {
            get { return _alternateName; }
            set { _alternateName = value; }
        }

        public string AlternateNameTriforce
        {
            get { return _alternateNameTriforce; }
            set { _alternateNameTriforce = value; }
        }

        #endregion

        public List<string> BatchNames()
        {
            var batchNames = new List<string>(4);

            AddNonEmptyStringTo(batchNames, _batchName);
            AddNonEmptyStringTo(batchNames, _legacyBatchName);
            AddNonEmptyStringTo(batchNames, _alternateName);
            AddNonEmptyStringTo(batchNames, _alternateNameTriforce);

            return batchNames;
        }

        private static void AddNonEmptyStringTo(List<string> batchNames, string batchName)
        {
            Ensure.Argument.NotNull(() => batchNames);
            Ensure.Argument.NotNullOrEmpty(() => batchName);
            if(!string.IsNullOrEmpty(batchName))
            {
                batchNames.Add(batchName);
            }
        }
    }
}