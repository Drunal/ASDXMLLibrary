﻿using AsdXMLLibrary.Base.Classifications;
using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace AsdXMLLibrary.Base
{
    /// <summary>
    /// Holds the chosen value and knowledge about the valid Values for this particular value.
    /// </summary>
    public class Classification : SerializeBase, IHaveValue
    {
        private ClassificationBase validValues;
        private bool isDummy = false;

        private string chosenValue;

        [XmlText]
        public string Value { get { return chosenValue; }
            set
            {
                if (!isDummy && !string.IsNullOrEmpty(value) && !validValues.Contains(value))
                    throw new ClassificationException(string.Format("Value '{0}' is not a valid value for {1}!", value, validValues.GetType().Name));
                chosenValue = value;
            }
        }

        #region Constructors
        public Classification()
            : this(Constants.DefaultClassificationElementName, typeof(DummyClassification))
        { 
            // TODO: write to logger, that we used the default elementName and a dummy Classification
            isDummy = true;
        }

        public Classification(string elementName, Type classificationType)
            : this(elementName, classificationType, null)
        { }

        public Classification(string elementName, Type classificationType, string value)
            : base(elementName)
        {
            validValues = ClassificationManager.Get(classificationType);
            Value = value;
        }

        #endregion

        public bool HasValue
        {
            get { return !string.IsNullOrEmpty(chosenValue); }
        }

        #region Serialize Funcctions
        /// <summary>
        /// Creates an XElement for this classification. 
        /// If no value is present, 'null' is returned. 
        /// Unless <paramref name="forceElement"/> is set to <c>True</c>.
        /// In this case the XElement is created and returned with no content. 
        /// </summary>
        /// <param name="ns">The namespace the element should be in.</param>
        /// <param name="forceElement">Define if the element must be created regardless of available content.</param>
        /// <returns></returns>
        public override XElement GetXML(XNamespace ns, bool forceElement=false)
        {
            return HasValue ? new XElement(ns + _elementName, chosenValue) : null;
        }

        public override bool ReadfromXML(XElement element, XNamespace ns)
        {
            if (element == null)
                return false; // so there was no element for language, meh

            chosenValue = element.Value;

            return true;
        }

        #endregion
    }
}
