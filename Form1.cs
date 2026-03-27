using System.Drawing.Text;
using TestWins.Controller;

namespace TestWins;

public partial class Form1 : Form
{

    private readonly StudentController controller = new StudentController();
    public Form1()
    {
        InitializeComponent();
        loadData();
    }

    private void loadData()
    {
        dataGridView1.DataSource = controller.getAll();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        Students s = new Students()
        {
            Name = txtName.Text,
            Age = int.Parse(txtAge.Text),
            Course = txtCourse.Text
        };
        controller.insert(s);
        loadData();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        Students S = new Students()
        {
            Id = int.Parse(txtId.Text),
            Name = txtName.Text,
            Age = int.Parse(txtAge.Text),
            Course = txtCourse.Text
        };
        controller.update(S);
        loadData(); 
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
       int id = int.Parse(txtId.Text);
        controller.delete(id);
        loadData();
    }

    private void dataGridView1_CellClick(object sender, EventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            txtId.Text = row.Cells["Id"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAge.Text = row.Cells["Age"].Value.ToString();
            txtCourse.Text = row.Cells["Course"].Value.ToString();s
        }
    }
}
