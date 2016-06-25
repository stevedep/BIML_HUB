using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace HUB
{
    public partial class Form1 : Form
    {

        public static string metadataConnectionString = "Server=10.1.7.101;Database=STGEDW;User Id=lala; Password=lala;";
        public List<ExtractTable> extractTables = new List<ExtractTable>();
        public List<SequenceContainer> Containers = new List<SequenceContainer>();

        public Form1()
        {
            InitializeComponent();
        }

        private void PopulateTables()
        {
            //  Variables used to retrieve and write data
            string query;
            DataTable tblExtractTables;

            //	Add ExtractTables
            query = "SELECT top 10"
            + "   'Extract_Entrino_' + bet.SourceTableName AS PackageName,"
            + "   bet.SequenceName,"
            + "   bet.SchemaName,"
            + "   bet.SourceSystemName,"
            + "   bet.SelectQuery,"
            + "   bet.ExtractTableName,"
            + "   bet.SourceTableName,"
            + "	  bet.ArchiveProcedure,"
            + "	  bet.SequenceContainerName"
            + " FROM META.BimlExtractArchivePackages AS bet";
            //+ " where bet.GenerateWithBiml = 1";

            tblExtractTables = Data.getData(query, metadataConnectionString);

            foreach (DataRow row in tblExtractTables.Rows)
            { // by adding                
                extractTables.Add(ExtractTable.fillExtractTable(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString()));
            }
        }

        private void PopulateContainers(List<ExtractTable> ExtractTables) {
            IEnumerable<string> LContainer = ExtractTables.Select(x => x.SequenceContainerName).Distinct();
            foreach (string container in LContainer) {
                Debug.WriteLine(container.ToString());
                List<ExtractTable> tables = extractTables.Where(x => x.SequenceContainerName.ToString() == container.ToString()).ToList();
                Containers.Add(SequenceContainer.fillContainerTable(container.ToString(), tables));
            }

        }

        private void WriteToBIML(string st, string path) {
            StringBuilder sb = new StringBuilder();
            sb.Append("<Biml xmlns=\"http://schemas.varigence.com/biml.xsd\">");
            sb.Append(st);
            sb.Append("</Biml>");
            using (System.IO.StreamWriter file =
                          new System.IO.StreamWriter(path, false))
            {
                file.WriteLine(sb);
            }
        }

        private void GenerateBimlPackages() {
            StringBuilder sb = new StringBuilder();
            sb.Append(System.IO.File.ReadAllText(@"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Connections.biml"));
            sb.Append("<Packages>");
            foreach (ExtractTable extractTable in extractTables)
                    {// The BIML code per package is appended.
                      //  Debug.WriteLine(extractTable.biml.ToString());
                        sb.Append(extractTable.biml.ToString());
                    }
            sb.Append("</Packages>");
                    WriteToBIML(sb.ToString(), @"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Development.biml");
        }



        private void btnGenerateOrch_Click(object sender, EventArgs e)
        {
            StringBuilder sb_packagecontent = new StringBuilder();
            StringBuilder sb_excecute_package = new StringBuilder();
            
            foreach (SequenceContainer sc in Containers) {
                foreach (ExtractTable t in sc.ExtractTables)
                {
                    sb_excecute_package.Append(t.biml_executepackage.ToString());
                }
                // set the inner part of the container to consist of excecute package tasks
                sc.innerpart = sb_excecute_package.ToString();
                // add final biml for contains the to package content string that is appended with multiple containers. 
                sb_packagecontent.Append(sc.biml.ToString());
              }

            StringBuilder sb_connectionstrings = new StringBuilder();            
            foreach (ExtractTable et in extractTables) {
                sb_connectionstrings.Append(et.biml_connection.ToString());
            }
                        
            Opackage OP = new Opackage();
            OP.innerpart = sb_packagecontent.ToString();
            OP.connections = sb_connectionstrings.ToString();
        
            WriteToBIML(OP.biml.ToString(), @"c:\TFS\Entrino Business Intelligence\Back-End\SSIS\Hub\Hub\Hub\Development.biml");

        }

       
        private void btnLoadExtractTables_Click(object sender, EventArgs e)
        {
            PopulateTables();
            MessageBox.Show("klaar");
        }

        private void brnContainersOrch_Click(object sender, EventArgs e)
        {
            PopulateContainers(extractTables);
            MessageBox.Show("klaar");
        }

        private void btnGenerateSinglePackages_Click(object sender, EventArgs e)
        {
            GenerateBimlPackages();
            MessageBox.Show("klaar");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (ExtractTable et in extractTables) {
                Debug.WriteLine(et.ArchiveProcedure.ToString());
            }
        }
    }
}
