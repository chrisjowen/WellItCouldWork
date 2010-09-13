using System.Collections.Generic;
using System.Xml;
using WellItCouldWork.SyntaxHelpers;

namespace WellItCouldWork.Investigation
{
    public class ProjectInvestigator
    {
        private List<ExternalReference> dependencies;
        private XmlNode projectDocumentRoot;

        private ProjectInvestigator()
        {
            dependencies = new List<ExternalReference>();
        }

        public static ProjectInvestigator InvestigateProject(string projectFile)
        {
            var investigator = new ProjectInvestigator();
            var projectDocument = new XmlDocument();
            projectDocument.Load(projectFile);
            investigator.projectDocumentRoot = projectDocument.DocumentElement;
            return investigator;
        }

        public IList<ExternalReference> TellMeAboutTheExternalDependencies()
        {
            if (!IKnowAboutTheProjectsExternalDependencies)
            {
                dependencies = InvestigateExternalDependencies();
                return dependencies;
            }

            return dependencies;
        }

        private List<ExternalReference> InvestigateExternalDependencies()
        {
            dependencies = new List<ExternalReference>();
            foreach (XmlNode referenceNode in projectDocumentRoot.ChildNodes[3].ChildNodes) //XPath is so anoying, come back
            {
                if (referenceNode.Attributes == null) continue;
                if (!referenceNode.HasChildNodes) continue;

                var dependencyName = referenceNode.Attributes["Include"].Value;
                var path = referenceNode.ChildNodes[0].InnerText;
                dependencies.Add(new ExternalReference(dependencyName, path));
            }
            return dependencies;
        }

        private bool IKnowAboutTheProjectsExternalDependencies
        {
            get { return dependencies.IsNotEmpty(); }
        }
    }
}