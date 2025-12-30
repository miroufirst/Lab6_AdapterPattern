using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Lab6_AdapterPattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupTable();
            AttachEvents();
        }

        private void SetupTable()
        {
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "ID";
                dataGridView1.Columns[1].Name = "Product";
                dataGridView1.Columns[2].Name = "Price";

                dataGridView1.Rows.Add("1", "Phone", "800");
                dataGridView1.Rows.Add("2", "Laptop", "1200");
            }
        }

        private void AttachEvents()
        {
            btnSaveText.Click += (s, e) => RunAdapter(new TextAdapter(dataGridView1), "data.txt", true);
            btnLoadText.Click += (s, e) => RunAdapter(new TextAdapter(dataGridView1), "data.txt", false);
            btnSaveBin.Click += (s, e) => RunAdapter(new BinaryAdapter(dataGridView1), "data.dat", true);
            btnLoadBin.Click += (s, e) => RunAdapter(new BinaryAdapter(dataGridView1), "data.dat", false);
        }

        private void RunAdapter(IGridAdapter adapter, string filename, bool isSave)
        {
            try
            {
                if (isSave)
                {
                    adapter.Save(filename);
                    MessageBox.Show($"Saved to {filename}");
                }
                else
                {
                    dataGridView1.Rows.Clear();
                    adapter.Load(filename);
                    MessageBox.Show($"Loaded from {filename}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }

    public class SimpleFileService
    {
        public void WriteRawText(string path, string content) => File.WriteAllText(path, content, Encoding.UTF8);

        public string ReadRawText(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            return File.ReadAllText(path, Encoding.UTF8);
        }

        public void WriteRawBytes(string path, byte[] data) => File.WriteAllBytes(path, data);

        public byte[] ReadRawBytes(string path)
        {
            if (!File.Exists(path)) throw new FileNotFoundException();
            return File.ReadAllBytes(path);
        }
    }

    public interface IGridAdapter
    {
        void Save(string filePath);
        void Load(string filePath);
    }

    public class TextAdapter : IGridAdapter
    {
        private DataGridView _grid;
        private SimpleFileService _service = new SimpleFileService();
        private const char Sep = ';';

        public TextAdapter(DataGridView grid) => _grid = grid;

        public void Save(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            foreach (DataGridViewRow row in _grid.Rows)
            {
                if (row.IsNewRow) continue;
                List<string> cells = new List<string>();
                foreach (DataGridViewCell cell in row.Cells)
                    cells.Add(cell.Value?.ToString().Replace(";", " ") ?? "");
                sb.AppendLine(string.Join(Sep.ToString(), cells));
            }
            _service.WriteRawText(filePath, sb.ToString());
        }

        public void Load(string filePath)
        {
            string content = _service.ReadRawText(filePath);
            _grid.Rows.Clear();
            string[] lines = content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines) _grid.Rows.Add(line.Split(Sep));
        }
    }

    public class BinaryAdapter : IGridAdapter
    {
        private DataGridView _grid;
        private SimpleFileService _service = new SimpleFileService();

        public BinaryAdapter(DataGridView grid) => _grid = grid;

        public void Save(string filePath)
        {
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter writer = new BinaryWriter(ms))
            {
                writer.Write(_grid.Rows.Count - 1);
                writer.Write(_grid.Columns.Count);
                foreach (DataGridViewRow row in _grid.Rows)
                {
                    if (row.IsNewRow) continue;
                    foreach (DataGridViewCell cell in row.Cells) writer.Write(cell.Value?.ToString() ?? "");
                }
                _service.WriteRawBytes(filePath, ms.ToArray());
            }
        }

        public void Load(string filePath)
        {
            using (MemoryStream ms = new MemoryStream(_service.ReadRawBytes(filePath)))
            using (BinaryReader reader = new BinaryReader(ms))
            {
                _grid.Rows.Clear();
                int rows = reader.ReadInt32();
                int cols = reader.ReadInt32();
                for (int i = 0; i < rows; i++)
                {
                    string[] rowData = new string[cols];
                    for (int j = 0; j < cols; j++) rowData[j] = reader.ReadString();
                    _grid.Rows.Add(rowData);
                }
            }
        }
    }
}