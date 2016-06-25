using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace HUB
{
    public class ExtractTable
    {
        // The two elements below are used for the single packages that are generated. 
        public string PackageNameVar { get; set; }
        public string biml { get; set; }

        // The elements below are used for the orchestration package
        public string biml_executepackage { get; set; }
        public string biml_connection { get; set; }
        public string biml_executearchive { get; set; }
                
        public string PackageName { get { return PackageNameVar; } set { 
            // single package
            biml = biml.Replace(PackageNameVar, value).ToString();
            // for the orchestration package
            biml_executepackage = biml_executepackage.Replace(PackageNameVar, value).ToString();
           // biml_executearchive = biml_executearchive.Replace(PackageNameVar, value).ToString();
            biml_connection = biml_connection.Replace(PackageNameVar, value).ToString();
            biml_executearchive = biml_executearchive.Replace(PackageNameVar, value).ToString();            
            PackageNameVar = value; } }
        public string SequenceName { get; set; }
        
        public string SchemaNameVar { get; set; }
        public string SchemaName { get { return SchemaNameVar; } set { biml = biml.Replace(SchemaNameVar, value); SchemaNameVar = value; } }

        public string SourceSystemNameVar { get; set; }
        public string SourceSystemName { get { return SourceSystemNameVar; } set { biml = biml.Replace(SourceSystemNameVar, value); SourceSystemNameVar = value; } }

        public string SelectQueryVar { get; set; }
        public string SelectQuery { get { return SelectQueryVar; } set { biml = biml.Replace(SelectQueryVar, value); SelectQueryVar = value; } }

        public string ExtractTableNameVar { get; set; }
        public string ExtractTableName { get { return ExtractTableNameVar; } set { biml = biml.Replace(ExtractTableNameVar, value); ExtractTableNameVar = value; } }

        public string SourceTableNameVar { get; set; }
        public string SourceTableName { get { return SourceTableNameVar; } set {
            biml = biml.Replace(SourceTableNameVar, value); biml_executearchive = biml_executearchive.Replace(SourceTableNameVar, value);
            SourceTableNameVar = value; } }

        public string ArchiveProcedureVar { get; set; }
        public string ArchiveProcedure { get { return ArchiveProcedureVar; } set { biml_executearchive = biml_executearchive.Replace(ArchiveProcedureVar, value).ToString(); ArchiveProcedureVar = value; } }          
        

        public string SequenceContainerName { get; set; }
        

        public static ExtractTable fillExtractTable
        (
            
            string PackageName,
            string SequenceName,            
            string SchemaName,
            string SourceSystemName,
            string SelectQuery,            
            string ExtractTableName,
            string SourceTableName,
            string ArchiveProcedure,
            string SequenceContainerName
            
        )
        {
            ExtractTable extractTable = new ExtractTable();

            extractTable.PackageName = PackageName;
            extractTable.SequenceName = SequenceName;            
            extractTable.SchemaName = SchemaName;
            extractTable.SourceSystemName = SourceSystemName;
            extractTable.SelectQuery = SelectQuery;            
            extractTable.ExtractTableName = ExtractTableName;
            extractTable.SourceTableName = SourceTableName;
            extractTable.ArchiveProcedure = ArchiveProcedure;
            extractTable.SequenceContainerName = SequenceContainerName;

            return extractTable;
        }

        public ExtractTable()
        {
            PackageNameVar = "<!--PackageName-->";
            SelectQueryVar = "<!--SelectQuery-->";
            SchemaNameVar = "<!--SchemaName-->";
            SourceTableNameVar = "<!--SourceTableName-->";
            SourceSystemNameVar = "<!--SourceSystem-->";
            ExtractTableNameVar = "<!--ExtractTableName-->";
            ArchiveProcedureVar = "<!--ArchiveProcedure-->";


            //Single packages
            biml = System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Package.biml");
            
            //Orchestration
            biml_executepackage = System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\ExcecutePackage.biml");
            biml_connection = System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Connection.biml");
            biml_executearchive = System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\ArchiveProcedure.biml");
        }

    }

    public class Opackage
    {
        public string biml { get; set; }
        private string innerpartvar { get; set; }
        public string innerpart { get{ return innerpartvar;} set{ biml = biml.Replace(innerpartvar, value); innerpartvar = value; }}
        private string connectionsvar { get; set; }
        public string connections { get { return connectionsvar; } set { biml = biml.Replace(connectionsvar, value); connectionsvar = value; } }

        public List<SequenceContainer> SequenceContainers { get; set; }

        public Opackage() {
            innerpartvar = "INNERPART";
            connectionsvar = "CONNECTIONS";
            biml = System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Opackage.biml");            
        }    
    }

    public class SequenceContainer
    {
        public string biml { get; set; }
        public string innerpartvar { get; set; }
        public string innerpart { get { return innerpartvar; } set { biml = biml.Replace(innerpartvar, value); innerpartvar = value; } }
        public string SequenceContainerNameVar { get; set; }
        public string SequenceContainerName { get { return SequenceContainerNameVar; } set { biml = biml.Replace(SequenceContainerNameVar, value); SequenceContainerNameVar = value; } }
        public List<ExtractTable> ExtractTables { get; set; }

        public SequenceContainer()
        {
            SequenceContainerNameVar = "SEQNaam";
            innerpartvar = "INNERPART";
            biml = System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Container.biml");
        }

        public static SequenceContainer fillContainerTable(string SequenceContainerName, List<ExtractTable> ExtractTables)        
        {
            SequenceContainer ContainerTemp = new SequenceContainer();
            ContainerTemp.SequenceContainerName = SequenceContainerName;
            ContainerTemp.ExtractTables = ExtractTables;

            return ContainerTemp;
        }

        }
    }
        
    
