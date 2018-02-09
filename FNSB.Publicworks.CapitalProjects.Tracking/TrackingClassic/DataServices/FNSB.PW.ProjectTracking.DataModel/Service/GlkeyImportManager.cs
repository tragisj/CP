using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FNSB.Publicworks.Projects.DataLayer.Service
{
    public class GlkeyImportManager
    {

        private readonly string _xmlFilePath;
        private readonly XDocument _keyfile;
        private readonly List<string> _keylist = new List<string>();

        //glkey/value pairs of the acceptions
        public Dictionary<string, string> AcceptionsDictionary { get; set; }

        public GlkeyImportManager(string acceptionFilePath)
        {
            _xmlFilePath = acceptionFilePath;
            _keyfile = XDocument.Load(acceptionFilePath);

            GlkeyDictionary();

            var list = _keyfile.Descendants("GlkeyPrevent").Select(c => c.Attribute("Glkey").Value);
            _keylist = list.ToList();
        }

        //Add acception item to the XML file
        public void AddAcception(string glkey, string description)
        {
            var xelement = _keyfile.XPathSelectElement("projecttracking/GlkeyPrevent[@Glkey ='" + glkey + "']");
            if (xelement != null) throw new ArgumentException();
            var xElement = _keyfile.Element("projecttracking");
            if (xElement != null)
                xElement.Add(new XElement("GlkeyPrevent", new XAttribute("Glkey", glkey), new XAttribute("Description", description)));
            _keyfile.Save(_xmlFilePath);
        }

        public void ModifyAcception(string glkey, string description)
        {
            var xelement = _keyfile.XPathSelectElement("projecttracking/GlkeyPrevent[@Glkey ='" + glkey + "']");
            xelement.Attribute("Description").Value = description;
            _keyfile.Save(_xmlFilePath);
        }

        public void RemoveAcception(string glkey)
        {
            _keyfile.XPathSelectElement("projecttracking/GlkeyPrevent[@Glkey = '" + glkey + "']").Remove();
            _keyfile.Save(_xmlFilePath);
        }

        private void GlkeyDictionary()
        {
            AcceptionsDictionary =
                _keyfile.Descendants("GlkeyPrevent")
                    .Select(sp => new
                    {
                        Key = sp.Attribute("Glkey").Value,
                        Desc = sp.Attribute("Description").Value
                    }).ToDictionary(sp => sp.Key, sp => sp.Desc);
        }

        public bool BlockGlkeyFromImport(string glkey)
        {
            return _keylist.Contains(glkey);
        }
    }
}
