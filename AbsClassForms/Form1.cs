using AbstractClass;
using System.Data;
using System.Data.Common;

namespace AbsClassForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DBJob db;

        private void button1_Click(object sender, EventArgs e)
        {
            string filename;
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                filename = openFileDialog1.FileName;
                db = new SQLiteDBJob(filename);
                //db = new MSSqlDBJob(filename); //уточнить строку подключения
            }
            //db.Conn.Open();
            string sql = "select * from sqlite_master"; //master_table для MSSql => information_schema.tables
            DataTable DtProduct = new DataTable();
            DbDataAdapter adProduct = db.GetDataAdapter(sql);
            adProduct.Fill(DtProduct);
            dataGridView1.DataSource = DtProduct;
        }
    }
}