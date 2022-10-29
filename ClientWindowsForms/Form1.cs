using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClientWindowsForms.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ClientWindowsForms
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string token)
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public async void LoadData()
        {
            //создание клиента и выгрузка данных
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7059/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // получаем ответ
                HttpResponseMessage response = await client.GetAsync("api/Clubs");

                if (response.IsSuccessStatusCode)
                {
                    // читаем ответ
                    string content = await response.Content.ReadAsStringAsync();
                    //добавить раскрывающийся заголовок "Клубы"
                    //добавить к корню последовательность клубов по типу, клуб 1, клуб 2, клуб 3, и при нажатии на клуб открывать название клуба и id

                    TreeNode rootNode = new TreeNode("База данных");
                    TreeNode tablesNode = new TreeNode("Таблицы");
                    TreeNode clubNode = new TreeNode("Клубы");

                    rootNode.Nodes.Add(tablesNode);

                    tablesNode.Nodes.Add(clubNode);

                    clubNode.Nodes.AddRange(ClubStructuresToTreeNodes(DeserializeClubs(content)));
                    treeView1.Nodes.Add(rootNode);


                    // treeView1.Nodes.AddRange(StructuresToTreeNodes(DeserializeData(content)));
                }
                else
                {
                    MessageBox.Show("Ошибка подключения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public ClubStructure[] DeserializeClubs(string data)
        {
            //десериализация данных
            var json = JToken.Parse(data);
            var result = json.ToObject<ClubStructure[]>();

            return result;
        }


        public TreeNode[] ClubStructuresToTreeNodes(ClubStructure[] structures)
        {
            //преобразование данных в дерево
            var result = new List<TreeNode>();
            foreach (var structure in structures)
            {
                var nodeName = new TreeNode(structure.Name);
                var nodeId = new TreeNode(structure.Id.ToString());
                nodeName.Tag = structure;
                nodeId.Tag = structure;
                var commonNode = new[] { nodeName, nodeId };
                if (structure.Childs != null)
                {
                    commonNode.Concat(ClubStructuresToTreeNodes(structure.Childs));
                }

                result.Add(new TreeNode(structure.Name, commonNode));
            }

            return result.ToArray();
        }

        private void авторизацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //open auth form
            AuthForm form2 = new AuthForm();
            form2.Show();
        }
    }
}